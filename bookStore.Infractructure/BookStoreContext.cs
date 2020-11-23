using bookStore.Domain.Models;
using bookStore.Infractructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace bookStore.Infractructure
{
    public class BookStoreContext : DbContext, IUnitOfWork
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }
        public DbSet<Book> Books {get;set;}
        public DbSet<Author> Authors { get; set; }
        public DbSet<Printing> Printings { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Book>().HasKey(x => x.Id);
            mb.Entity<Book>().Property(x => x.Illustrations).HasMaxLength(15);
            mb.Entity<Book>().Property(x => x.Language).HasMaxLength(15).IsRequired();
            mb.Entity<Book>().Property(x => x.Price).IsRequired().HasColumnType("money");
            mb.Entity<Book>().Property(x => x.Image).HasColumnType("image");

            mb.Entity<Book>().HasOne(x => x.author).WithMany(x => x.books).HasForeignKey(x => x.AuthorId);
            mb.Entity<Book>().HasOne(x => x.printing).WithMany(x => x.books).HasForeignKey(x => x.PrintingId);

            mb.Entity<Author>().HasKey(x => x.Id);
            mb.Entity<Author>().Property(x => x.Name).HasMaxLength(40).IsRequired();
            mb.Entity<Author>().Property(x => x.Biography).HasMaxLength(300);
            mb.Entity<Author>().Property(x => x.Image).HasColumnType("image");

            mb.Entity<Printing>().HasKey(x => x.Id);
            mb.Entity<Printing>().Property(x => x.Name).HasMaxLength(30).IsRequired();
            mb.Entity<Printing>().Property(x => x.Location).HasMaxLength(100);
            mb.Entity<Printing>().Property(x => x.Type).HasMaxLength(30);
            
        }
       
    }
    


}
