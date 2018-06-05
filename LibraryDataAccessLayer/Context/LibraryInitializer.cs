using System;
using System.Collections.Generic;
using System.Data.Entity;
using Library.DAL.Entities;

namespace Library.DAL.Context
{
    public class LibraryInitializer: DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            var books = new List<Book>
            {
                new Book { Title = "1984", Theme_Id = 1, Price = 2.0, PenaltyType = Penalty.Medium, IsReturned = false },
                new Book { Title = "Animal Farm", Theme_Id = 2, Price = 3.0, PenaltyType = Penalty.Medium, IsReturned = true }
            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            var clients = new List<Client>
            {
                new Client { FullName = "Vasya Petrov", Phone = "0972153457", Passport = "AO012584", RegistrationDate = DateTime.Now },
                new Client { FullName = "Kolya Savushkin", Phone = "0972374581", Passport = "AO231854", RegistrationDate = DateTime.Now }
            };
            clients.ForEach(c => context.Clients.Add(c));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order { Book_Id = 1, Client_Id = 2, OrderDate = DateTime.Now.AddDays(-14).Date, ReturnDate = DateTime.Now.AddDays(-7).Date, IsCompleted = false }
            };
            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();

            var themes = new List<Theme>
            {
                new Theme { Topic = "novel-dystopia" },
                new Theme { Topic = "tale" }
            };
            themes.ForEach(t => context.Themes.Add(t));
            context.SaveChanges();

            var authors = new List<Author>
            {
                new Author { Name = "George", Surname = "Orwell"}
            };
            authors.ForEach(a => context.Authors.Add(a));
            context.SaveChanges();

            var authorBook = new List<AuthorBook>
            {
                new AuthorBook { Book_Id = 1, Author_Id = 1 },
                new AuthorBook { Book_Id = 2, Author_Id = 1 }
            };
            authorBook.ForEach(o => context.Author_Book.Add(o));
            context.SaveChanges();
        }
    }
}