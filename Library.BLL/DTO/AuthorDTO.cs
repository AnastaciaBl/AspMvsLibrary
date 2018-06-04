using System.Collections.Generic;

namespace Library.BLL.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //public virtual ICollection<BookDTO> Books { get; set; }

        //public AuthorDTO()
        //{
        //    Books = new List<BookDTO>();
        //}
    }
}
