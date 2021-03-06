﻿using System.Data.Entity;
using Library.DAL.Entities;

namespace Library.DAL.Context
{
    public class LibraryContext: DbContext
    {
        public LibraryContext():base("DbConnection") { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> Author_Book { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Theme> Themes { get; set; }

        static LibraryContext()
        {
            Database.SetInitializer<LibraryContext>(new LibraryInitializer());
        }

        public LibraryContext(string connectionString) : base(connectionString) { }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Book>().HasMany(b => b.Authors)
        //        .WithMany(a => a.Books)
        //        .Map(t => t.MapLeftKey("Book_Id")
        //        .MapRightKey("Author_Id")
        //        .ToTable("AuthorBooks"));
        //}
    }
}
