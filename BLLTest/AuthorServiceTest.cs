using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.BLL.Services;
using System.Collections.Generic;
using Moq;
using Library.DAL.Interfaces;
using Library.BLL.DTO;
using Library.DAL.Entities;

namespace BLLTest
{
    [TestClass]
    public class AuthorServiceTest
    {
        private static AuthorManager authorService;
        private static Mock<IUnitOfWork> databaseMock;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            databaseMock = new Mock<IUnitOfWork>();
            authorService = new AuthorManager(databaseMock.Object);
        }

        [TestMethod]
        public void Create_Author_Test()
        {
            var author = new AuthorDTO
            {
                Name = "test",
                Surname = "testS"
            };

            bool IsCreated = false;

            databaseMock.Setup(a => a.Authors.Create(It.Is<Author>
                (pr =>
                        (pr.Id == author.Id) &&
                        (pr.Name == author.Name) &&
                        (pr.Surname == author.Surname)))).Callback(() => IsCreated = true);

            authorService.Create(author);
            Assert.IsTrue(IsCreated);
        }

        [TestMethod]
        public void Get_AuthorById_Not_Null_Test()
        {
            databaseMock.Setup(a => a.Authors.Get(It.IsAny<int>())).Returns(new Author()
            {
                Id=1,
                Name ="Test",
                Surname = "Test"
            });

            var result = authorService.GetAuthor(It.IsAny<int>());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get_Authors_Not_Null_Test()
        {
            databaseMock.Setup(a => a.Authors.GetAll()).Returns(new List<Author>
            {
                new Author { Id=1, Name="Test", Surname = "Test" },
                new Author { Id=2, Name="Test", Surname = "Test" },
                 new Author { Id=3, Name="Test", Surname = "Test" }
            });

            var result = authorService.GetAuthors();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Update_Author_Test()
        {
            var author = new AuthorDTO
            {
                Id = 1,
                Name = "test",
                Surname = "testS"
            };

            bool IsUpdated = false;

            databaseMock.Setup(a => a.Authors.Update(It.Is<Author>
                (pr =>
                        (pr.Id == author.Id) &&
                        (pr.Name == author.Name) &&
                        (pr.Surname == author.Surname)))).Callback(() => IsUpdated = true);

            authorService.Update(author);
            Assert.IsTrue(IsUpdated);
        }
    }
}
