using System;
using System.Collections.Generic;

namespace Library.BLL.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<OrderDTO> Orders { get; set; }

        public ClientDTO()
        {
            Orders = new List<OrderDTO>();
        }
    }
}
