using Library.BLL.Interfaces;
using System;
using System.Collections.Generic;
using Library.BLL.DTO;
using Library.DAL.Interfaces;
using AutoMapper;
using Library.DAL.Entities;

namespace Library.BLL.Services
{
    public class ClientManager : IClientManager
    {
        IUnitOfWork Database { get; set; }

        public ClientManager(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(ClientDTO client)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
            var clientCreate = new Client
            {
                FullName = client.FullName,
                Phone = client.Phone,
                Passport = client.Passport,
                RegistrationDate = DateTime.Now,
            };
            Database.Clients.Create(clientCreate);
        }

        public void Delete(int id)
        {
            Database.Clients.Delete(id);
        }

        public ClientDTO GetClient(int id)
        {
            var client = Database.Clients.Get(id);
            var clientDTO = new ClientDTO()
            {
                FullName = client.FullName,
                Phone = client.Phone,
                Passport = client.Passport,
                RegistrationDate = client.RegistrationDate,
            };
            return clientDTO;
        }

        public IEnumerable<ClientDTO> GetClients()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Client>, IEnumerable<ClientDTO>>(Database.Clients.GetAll());
        }

        public void Update(ClientDTO client)
        {
            var updateClient = Database.Clients.Get(client.Id);
            updateClient.FullName = client.FullName;
            updateClient.Phone = client.Phone;
            updateClient.Passport = client.Passport;
            Database.Clients.Update(updateClient);
        }
    }
}
