using Library.BLL.DTO;
using System.Collections.Generic;

namespace Library.BLL.Interfaces
{
    public interface IAuthorManager
    {
        IEnumerable<AuthorDTO> GetAuthors();
        IEnumerable<BookDTO> GetBooks(int authorID);
        AuthorDTO GetAuthor(int id);
        void Create(AuthorDTO author);
        void Update(AuthorDTO author);
        void Delete(int id);
    }
}
