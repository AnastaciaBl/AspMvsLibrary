using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationLibrary.Models
{
    public class Order
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int Book_Id { get; set; }
        [Key, Column(Order = 2)]
        public int Client_Id { get; set; }
        [Key, Column(Order = 3)]
        public DateTime OrderDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
