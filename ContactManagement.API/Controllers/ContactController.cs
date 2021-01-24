using AutoMapper;
using ContactManagement.API.APIModels;
using ContactManagement.API.Logger;
using ContactManagement.Core;
using ContactManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public IEnumerable<ContactAPIModel> Get()
        {
            _logger.LogInformation("Begin - Get Contacts");

            var response = _mapper.Map<ICollection<ContactAPIModel>>(_contactService.GetAllContacts());
            if(response == null)
            {
                throw new Exception("Error in Get Contacts");
            }

            _logger.LogInformation("End - Get Contacts");

            return response;
        }

        /// <summary>
        /// Returns contact by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ContactAPIModel Get(int id)
        {
            _logger.LogInformation("Begin - Get Contact By Id");

            var response = _mapper.Map<ContactAPIModel>(_contactService.GetContact(id));

            _logger.LogInformation("End - Get Contact By Id");

            return response;
        }

        /// <summary>
        /// Create new contact
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public void Post([FromBody] ContactAPIModel input)
        {
            _logger.LogInformation("Begin - Create Contact");

            var contact = _mapper.Map<ContactDTO>(input);

            _contactService.CreateContact(contact);

            _logger.LogInformation("End - Create Contact");
        }

        /// <summary>
        /// Update Existing Contact
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ContactAPIModel input)
        {
            _logger.LogInformation("Begin - Update Contact");

            var contact = _contactService.GetContact(id);

            if(contact == null)
            {
                throw new Exception("Bad request");
            }

            var mappedInput = _mapper.Map<ContactDTO>(input);
            mappedInput.Id = id;

            _contactService.UpdateContact(mappedInput);

            _logger.LogInformation("End - Update Contact");
        }

        /// <summary>
        /// Delete contact for given Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogInformation("Begin - Delete Contact");

            var contact = _contactService.GetContact(id);

            if (contact == null)
            {
                throw new Exception("Bad request");
            }

            _contactService.DeleteContact(id);

            _logger.LogInformation("End - Delete Contact");
        }
    }
}
