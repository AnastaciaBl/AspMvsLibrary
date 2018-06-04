using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.BLL.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebApplicationLibrary.Models
{
    [Table("Book")]
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Theme { get; set; }
        public int ThemeId { get; set; }
        public double Price { get; set; }
        public bool IsReturned { get; set; }
        //public Penalty PenaltyType { get; set; }
        public IEnumerable<AuthorViewModel> Authors { get; set; }
        public IEnumerable<DropDownList> AuthorsSelectList { get; set; }
        public List<int> SelectedAuthorId { get; set; }

        public BookViewModel()
        {
            Authors = new List<AuthorViewModel>();
        }
    }
}
