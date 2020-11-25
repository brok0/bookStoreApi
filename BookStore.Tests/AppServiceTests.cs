using bookStore.BusinessLogic.Services;
using bookStore.Domain.Models;
using bookStore.Infractructure.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Tests
{
    public class AppServiceTests
    {
        [Fact]
        public async Task AddBook_returnBook()
        {
            //arrange
            var book = new Book
            {
                Id = 0,
                Illustrations = "",
                Year = 0,
                Cover = "",
                Edition = "",
                Pages = 0,
                Language = "",
                printing = new Printing { Id = 1, Name = "" },
                author = new Author { Id = 1, Name = "" },
                AuthorId = 1,
                PrintingId = 1,
            };

            var repoMock = new Mock<IBookRepository>();
            repoMock.Setup(x => x.Insert(It.IsAny<Book>())).Returns(book);
            repoMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new AppService(repoMock.Object,null,null);
            //act

            var actualResult = await service.AddNewBookAsync(book);


            //assert
            Assert.NotNull(actualResult);
        }

        [Fact]
        public async Task CreateAuthor_ReturnAuthor()
        {
            var author = new Author { Id = 0, Name = "name" };
            //arrange 
            var repoMock = new Mock<IAuthorRepository>();
            repoMock.Setup(x => x.Insert(It.IsAny<Author>())).Returns(author);
            repoMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new AppService(null, repoMock.Object, null);

            //act 

            var actualResult = await service.AddAuthorAsync(author);

            //assert 
            Assert.NotNull(actualResult);
        }

        [Fact]
        public async Task CreatePrinting_ReturnPrinting()
        {
            var printing = new Printing { Id = 0, Name = "name" };
            //arrange 
            var repoMock = new Mock<IPrintingRepository>();
            repoMock.Setup(x => x.Insert(It.IsAny<Printing>())).Returns(printing);
            repoMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new AppService(null, null,repoMock.Object);

            //act 

            var actualResult = await service.AddPrintingAsync(printing);

            //assert 
            Assert.NotNull(actualResult);
        }

        [Fact]
        public async Task UpdateBook_ChangeTitle_SuccesfullBehaviour ()
        {
            var book = new Book
            {
                Id = 0,
                Illustrations = "",
                Year = 0,
                Cover = "",
                Edition = "",
                Pages = 0,
                Language = "",
                printing = new Printing { Id = 1, Name = "" },
                author = new Author { Id = 1, Name = "" },
                AuthorId = 1,
                PrintingId = 1,
                Title ="oldTitel"
            };
            //arrange 
            var repoMock = new Mock<IBookRepository>();
            repoMock.Setup(x => x.Insert(It.IsAny<Book>())).Returns(book);
            repoMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(book));
            repoMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new AppService(repoMock.Object,null, null );

            //act 
            var oldtitle = book.Title;
            var updateBook = book;
            updateBook.Title = "newTitle";
            var actualResult = await service.UpdateBookAsync(updateBook);

            //assert 
            Assert.Equal(actualResult.Title, book.Title);
            Assert.NotEqual(actualResult.Title, oldtitle);
        }


    }
}
