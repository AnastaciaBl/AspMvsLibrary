using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public class Theme
    {
        [Key]
        public int Id { get; set; }
        public string Topic { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Theme()
        {
            Books = new List<Book>();
        }
    }
}