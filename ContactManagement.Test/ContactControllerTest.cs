using AutoMapper;
using ContactManagement.API.APIModels;
using ContactManagement.API.Controllers;
using ContactManagement.API.Logger;
using ContactManagement.Core;
using ContactManagement.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManagement.Test
{
    [TestFixture]
    public class ContactControllerTest
    {
        Mock<IContactManagementService> _contactService;
        Mock<IMapper> _mapper;
        Mock<ILoggerManager> _loggerManager;

        ContactController _contactController;

        [SetUp]
        public void Setup()
        {
            _contactService = new Mock<IContactManagementService>();
            _mapper = new Mock<IMapper>();
            _loggerManager = new Mock<ILoggerManager>();

            _contactController = new ContactController(_contactService.Object, _mapper.Object, _loggerManager.Object);
        }

        [Test]
        public void GetAllContact_Success()
        {
            _loggerManager.Setup(l => l.LogInformation(It.IsAny<string>())).Verifiable();

            _contactService.Setup(s => s.GetAllContacts()).Returns(Task.FromResult<ICollection<ContactDTO>>(
                new List<ContactDTO>() { 
                    new ContactDTO { FirstName = "Abc", Status = ContactStatusDTO.Active},
                    new ContactDTO { FirstName = "Pqr", Status = ContactStatusDTO.Active},
                    new ContactDTO { FirstName = "Xyz", Status = ContactStatusDTO.Inactive}
                }));

            _mapper.Setup(m => m.Map<IList<ContactAPIModel>>(It.IsAny<ICollection<ContactStatusDTO>>())).Returns(
                new List<ContactAPIModel>() {
                    new ContactAPIModel { FirstName = "Abc", Status = ContactStatusAPIModel.Active},
                    new ContactAPIModel { FirstName = "Pqr", Status = ContactStatusAPIModel.Active},
                    new ContactAPIModel { FirstName = "Xyz", Status = ContactStatusAPIModel.Inactive}
                }
                );

            var result = _contactController.Get();

            Assert.IsNotNull(result);
            Assert.IsNotInstanceOf<ICollection<ContactAPIModel>>(result);
        }



        [Test]
        public void GetAllContact_Failed()
        {
            _loggerManager.Setup(l => l.LogInformation(It.IsAny<string>())).Verifiable();

            _contactService.Setup(s => s.GetAllContacts()).Returns(Task.FromResult((ICollection<ContactDTO>)null));

            _mapper.Setup(m => m.Map<ICollection<ContactAPIModel>>(It.IsAny<ICollection<object>>())).Returns((ICollection<ContactAPIModel>)null);

            Assert.DoesNotThrow(() =>
            {
                var result = _contactController.Get();
            }); 
        }

        [TearDown]
        public void CleanUp()
        {
            _contactService = null;
            _mapper = null;
            _loggerManager = null;
        }
    }
}