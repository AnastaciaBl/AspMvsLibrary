using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.BLL.Services;
using System.Collections.Generic;
using Moq;
using Library.DAL.Interfaces;
using Library.BLL.DTO;
using Library.DAL.Entities;
using System;

namespace BLLTest
{
    [TestClass]
    class ClientServiceTest
    {
        private static ClientManager clientService;
        private static Mock<IUnitOfWork> databaseMock;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            databaseMock = new Mock<IUnitOfWork>();
            clientService = new ClientManager(databaseMock.Object);
        }

        [TestMethod]
        public void Create_Client_Test()
        {
            var client = new ClientDTO
            {
                FullName = "test",
                Phone = "test",
                Passport = "test",
                RegistrationDate = DateTime.Now,
            };

            bool IsCreated = false;

            databaseMock.Setup(a => a.Clients.Create(It.Is<Client>
                (pr =>
                        (pr.Id == client.Id) &&
                        (pr.FullName == client.FullName) &&
                        (pr.Phone == client.Phone) &&
                        (pr.Passport == client.Passport) &&
                        (pr.RegistrationDate == client.RegistrationDate)))).Callback(() => IsCreated = true);

            clientService.Create(client);
            Assert.IsTrue(IsCreated);
        }

        [TestMethod]
        public void Get_ClientById_Not_Null_Test()
        {
            databaseMock.Setup(a => a.Clients.Get(It.IsAny<int>())).Returns(new Client()
            {
                Id = 1,
                FullName = "test",
                Phone = "test",
                Passport = "test",
                RegistrationDate = DateTime.Now
            });

            var result = clientService.GetClient(It.IsAny<int>());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get_Clients_Not_Null_Test()
        {
            databaseMock.Setup(a => a.Clients.GetAll()).Returns(new List<Client>
            {
                new Client { Id=1, FullName="Test", Phone = "Test", Passport = "test", RegistrationDate = It.IsAny<DateTime>() },
                new Client { Id=2, FullName="Test", Phone = "Test", Passport = "test", RegistrationDate = It.IsAny<DateTime>() },
                 new Client { Id=3, FullName="Test", Phone = "Test", Passport = "test", RegistrationDate = It.IsAny<DateTime>() }
            });

            var result = clientService.GetClients();

            Assert.IsNotNull(result);
        }
    }
}
