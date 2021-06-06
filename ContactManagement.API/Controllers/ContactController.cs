using AutoMapper;
using ContactManagement.API.APIModels;
using ContactManagement.API.Logger;
using ContactManagement.Core;
using ContactManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactManagementService _contactService;
        IMapper _mapper; 
        private readonly ILoggerManager _logger;

        public ContactController(IContactManagementService contactService, IMapper mapper, ILoggerManager logger)
        {
            if (contactService == null)
                throw new Exception($"{typeof(IContactManagementService)} not initialized");
            if (mapper == null)
                throw new Exception($"{typeof(IMapper)} not initialized");
            if (logger == null)
                throw new Exception($"{typeof(ILoggerManager)} not initialized");

            this._contactService = contactService;
            this._mapper = mapper;
            this._logger = logger;
        }
        
        /// <summary>
        /// Returns all contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactAPIModel>>> Get()
        {
            _logger.LogInformation("Begin - Get Contacts");

            var response = _mapper.Map<ICollection<ContactAPIModel>>(await _contactService.GetAllContacts());
            if(response == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            _logger.LogInformation("End - Get Contacts");

            return Ok(response);
        }

        /// <summary>
        /// Returns contact by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactAPIModel>> Get(int id)
        {
            _logger.LogInformation("Begin - Get Contact By Id");

            var response = _mapper.Map<ContactAPIModel>(await _contactService.GetContact(id));

            _logger.LogInformation("End - Get Contact By Id");

            return response;
        }

        /// <summary>
        /// Create new contact
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContactAPIModel input)
        {
            _logger.LogInformation("Begin - Create Contact");

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = _mapper.Map<ContactDTO>(input);

            await _contactService.CreateContact(contact);

            _logger.LogInformation("End - Create Contact");

            return StatusCode(StatusCodes.Status202Accepted);
        }

        /// <summary>
        /// Update Existing Contact
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ContactAPIModel input)
        {
            _logger.LogInformation("Begin - Update Contact");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = await _contactService.GetContact(id);

            if(contact == null)
            {
                return BadRequest();
            }

            var mappedInput = _mapper.Map<ContactDTO>(input);
            mappedInput.Id = id;

            await _contactService.UpdateContact(mappedInput);

            _logger.LogInformation("End - Update Contact");

            return StatusCode(StatusCodes.Status202Accepted);
        }

        /// <summary>
        /// Delete contact for given Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Begin - Delete Contact");

            var contact = _contactService.GetContact(id);

            if (contact == null)
            {
                return BadRequest();
            }

            await _contactService.DeleteContact(id);

            _logger.LogInformation("End - Delete Contact");

            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
