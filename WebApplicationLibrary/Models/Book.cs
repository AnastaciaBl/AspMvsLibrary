using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationLibrary.Models
{
    public class Book
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Theme_Id { get; set; }
        public double Price { get; set; }
        public bool IsReturned { get; set; }
        public Penalty PenaltyType { get; set; }
        public virtual ICollection<Author> Authors { get; set; }

        public Book()
        {
            Authors = new List<Author>();
        }
    }
}
