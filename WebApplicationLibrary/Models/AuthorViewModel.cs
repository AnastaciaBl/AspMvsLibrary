using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationLibrary.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Surname { get; set; }
        public virtual IEnumerable<BookViewModel> Books { get; set; }

        public AuthorViewModel()
        {
            Books = new List<BookViewModel>();
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}