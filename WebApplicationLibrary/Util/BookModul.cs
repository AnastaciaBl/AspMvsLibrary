using Ninject.Modules;
using Library.BLL.Services;
using Library.BLL.Interfaces;

namespace WebApplicationLibrary.Util
{
    public class BookModul : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookManager>().To<BookManager>();
            Bind<IAuthorManager>().To<AuthorManager>();
        }
    }
}