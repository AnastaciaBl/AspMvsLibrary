using Library.BLL.DTO;
using System;
using System.Collections.Generic;

namespace Library.BLL.Interfaces
{
    public interface IOrderManager
    {
        IEnumerable<OrderDTO> GetOrders();
        OrderDTO GetOrder(int bookId, int clientId, DateTime orderDate);
        void Create(OrderDTO order, List<BookDTO> books);
        void Update(OrderDTO order);
        //void Delete(int bookId, int clientId, DateTime orderDate);
    }
}
