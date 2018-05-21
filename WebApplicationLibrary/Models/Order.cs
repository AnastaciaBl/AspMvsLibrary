using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationLibrary.Models
{
    public class Order
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int Id_Book { get; set; }
        public int Id_Client { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
