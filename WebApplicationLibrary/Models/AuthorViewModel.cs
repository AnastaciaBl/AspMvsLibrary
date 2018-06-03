using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.BLL.DTO;

namespace WebApplicationLibrary.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual IEnumerable<BookViewModel> Books { get; set; }

        public AuthorViewModel()
        {
            Books = new List<BookViewModel>();
        }

        public AuthorViewModel(AuthorDTO _author):this()
        {
            Id = _author.Id;
            Name = _author.Name;
            Surname = _author.Surname;
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}