using System.Collections.Generic;
using Library.BLL.DTO;

namespace Library.BLL.Interfaces
{
    public interface IBookManager
    {
        IEnumerable<BookDTO> GetBooks();
        IEnumerable<AuthorDTO> GetAuthors(int bookID);
        BookDTO GetBook(int id);
        string GetTheme(int themeID);
        List<ThemeDTO> GetAllTheme();
        void Create(BookDTO book, List<int> authorsIds);
        void Update(BookDTO book);
        void Delete(int id);
    }
}
