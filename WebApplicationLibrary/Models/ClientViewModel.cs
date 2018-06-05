using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationLibrary.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }
        //public ICollection<OrderViewModel> Orders { get; set; }

        //public ClientViewModel()
        //{
        //    Orders = new List<OrderViewModel>();
        //}
    }
}