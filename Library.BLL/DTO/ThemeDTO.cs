using System.Collections.Generic;

namespace Library.BLL.DTO
{
    public class ThemeDTO
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public virtual ICollection<BookDTO> Books { get; set; }

        public ThemeDTO()
        {
            Books = new List<BookDTO>();
        }
    }
}
