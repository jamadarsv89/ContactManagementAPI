using AutoMapper;
using ContactManagement.API.APIModels;
using ContactManagement.API.Controllers;
using ContactManagement.API.Logger;
using ContactManagement.Core;
using ContactManagement.Data;
using ContactManagement.Data.Entity;
using ContactManagement.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ContactManagement.Test
{
    [TestFixture]
    public class ContactManagementServiceTest
    {
        Mock<IMapper> _mapper;
        Mock<IRepository<Contact>> _contactRepository;

        ContactManagementService _contactManagementService;

        [SetUp]
        public void Setup()
        {
            _mapper = new Mock<IMapper>();
            _contactRepository = new Mock<IRepository<Contact>>();

            _contactManagementService = new ContactManagementService(_contactRepository.Object, _mapper.Object);
        }

        [TearDown]
        public void CleanUp()
        {
            _contactManagementService = null;
            _mapper = null;
            _contactRepository = null;
        }
    }
}