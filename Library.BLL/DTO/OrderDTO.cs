using System;

namespace Library.BLL.DTO
{
    public class OrderDTO
    {
        public int Book_Id { get; set; }
        public int Client_Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
