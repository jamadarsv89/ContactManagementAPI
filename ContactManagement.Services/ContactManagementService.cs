using AutoMapper;
using ContactManagement.Core;
using ContactManagement.Data;
using ContactManagement.Data.Entity;
using System;
using System.Collections.Generic;

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
        public void CreateContact(ContactDTO contact)
        {
            _repository.Insert(_mapper.Map<Contact>(contact));

            _repository.Save();
        }

        public void DeleteContact(int id)
        {
            _repository.Delete(id);

            _repository.Save();
        }

        public ICollection<ContactDTO> GetAllContacts()
        {
            return _mapper.Map<ICollection<ContactDTO>>(_repository.GetAll());
        }

        public ContactDTO GetContact(int id)
        {
            return _mapper.Map<ContactDTO>(_repository.GetById(id));
        }

        public void UpdateContact(ContactDTO contact)
        {
            _repository.Update(_mapper.Map<Contact>(contact));

            _repository.Save();
        }
    }
}
