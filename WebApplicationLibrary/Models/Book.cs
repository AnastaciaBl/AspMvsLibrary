using System.ComponentModel.DataAnnotations;

namespace WebApplicationLibrary.Models
{
    public class Book
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Author_Id { get; set; }
        public int Theme_Id { get; set; }
        public double Price { get; set; }
    }
}
