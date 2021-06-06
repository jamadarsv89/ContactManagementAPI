using AutoMapper;
using ContactManagement.Core;
using ContactManagement.Data;
using ContactManagement.Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManagement.Services
{
    public class ContactManagementService : IContactManagementService
    {
        IRepository<Contact> _repository;
        IMapper _mapper;

        public ContactManagementService(IRepository<Contact> repository, IMapper mapper)
        {
            if (repository == null)
                throw new Exception($"{typeof(ContactRepository)} not initialized");
            if (mapper == null)
                throw new Exception($"{typeof(IMapper)} not initialized");

            this._mapper = mapper;
            this._repository = repository;
        }
        public async Task CreateContact(ContactDTO contact)
        {
            await _repository.Insert(_mapper.Map<Contact>(contact));

            await _repository.Save();
        }

        public async Task DeleteContact(int id)
        {
            await _repository.Delete(id);

            await _repository.Save();
        }

        public async Task<ICollection<ContactDTO>> GetAllContacts()
        {
            return _mapper.Map<ICollection<ContactDTO>>(await _repository.GetAll());
        }

        public async Task<ContactDTO> GetContact(int id)
        {
            return _mapper.Map<ContactDTO>(await _repository.GetById(id));
        }

        public async Task UpdateContact(ContactDTO contact)
        {
            _repository.Update(_mapper.Map<Contact>(contact));

            await _repository.Save();
        }
    }
}
