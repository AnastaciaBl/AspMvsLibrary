using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationLibrary.Models
{
    public class AuthorBook
    {
        [Key, Column(Order = 1)]
        public int Book_Id { get; set; }
        [Key, Column(Order = 2)]
        public int Author_Id { get; set; }
    }
}