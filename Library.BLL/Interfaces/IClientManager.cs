using Library.BLL.DTO;
using System.Collections.Generic;

namespace Library.BLL.Interfaces
{
    public interface IClientManager
    {
        IEnumerable<ClientDTO> GetClients();
        //IEnumerable<OrderDTO> GetOrders(int clientID);
        ClientDTO GetClient(int id);
        void Create(ClientDTO client);
        void Update(ClientDTO client);
        void Delete(int id);
    }
}
