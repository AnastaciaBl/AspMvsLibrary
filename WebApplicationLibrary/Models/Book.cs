using System.ComponentModel.DataAnnotations;

namespace WebApplicationLibrary.Models
{
    public class Book
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }
        public double Price { get; set; }
    }
}
