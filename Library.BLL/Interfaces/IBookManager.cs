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
        IEnumerable<BookDTO> GetBookAuthors(int bookID);
        IEnumerable<BookDTO> GetBooksByTheme(string theme);
        IEnumerable<BookDTO> GetBooksByStatus(bool isReturned);
        string GetTheme(int themeID);
        void Create(BookDTO book);
        void Update(BookDTO book);
        void Delete(int id);
    }
}
