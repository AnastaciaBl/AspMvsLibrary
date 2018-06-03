using System.Collections.Generic;
using Library.DAL.Entities;

namespace Library.BLL.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Theme_Id { get; set; }
        public double Price { get; set; }
        public bool IsReturned { get; set; }
        public Penalty PenaltyType { get; set; }
        public virtual ICollection<AuthorDTO> Authors { get; set; }

        public BookDTO()
        {
            Authors = new List<AuthorDTO>();
        }
    }
}
