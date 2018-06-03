using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.BLL.DTO;

namespace WebApplicationLibrary.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Theme_Id { get; set; }
        public double Price { get; set; }
        public bool IsReturned { get; set; }
        //public Penalty PenaltyType { get; set; }
        public virtual ICollection<AuthorViewModel> Authors { get; set; }

        public BookViewModel()
        {
            Authors = new List<AuthorViewModel>();
        }

        public BookViewModel(BookDTO _book, ICollection<AuthorDTO> _author):this()
        {
            Id = _book.Id;
            Title = _book.Title;
            Theme_Id = _book.Theme_Id;
            Price = _book.Price;
            IsReturned = _book.IsReturned;
            foreach(var a in _author)
                Authors.Add(new AuthorViewModel(a));
        }
    }
}
