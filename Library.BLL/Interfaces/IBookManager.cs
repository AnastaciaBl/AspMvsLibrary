using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.DTO;

namespace Library.BLL.Interfaces
{
    public interface IBookManager
    {
        IEnumerable<BookDTO> GetBooks();
        IEnumerable<AuthorDTO> GetAuthors(int bookID);
        BookDTO GetBook(int id);
        string GetTheme(int themeID);
        void Create(BookDTO book);
        void Update(BookDTO book);
        void Delete(int id);
    }
}
