using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using StoreServices.Api.Book.Application;
using StoreServices.Api.Book.Model;
using StoreServices.Api.Book.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StoreServices.Api.Book.Tests
{
    public class BookServiceTests
    {
        private IEnumerable<BookMaterial> GetDataTest()
        {
            A.Configure<BookMaterial>()
                .Fill(x => x.Tittle).AsArticleTitle()
                .Fill(x => x.Id, () => { return new Guid(); });

            var list = A.ListOf<BookMaterial>(30);
            list[0].Id = Guid.Empty;

            return list;
        }

        private Mock<BookContext> CreateContext()
        {
            var dataTest = GetDataTest().AsQueryable();

            var dbSet = new Mock<DbSet<BookMaterial>>();
            dbSet.As<IQueryable<BookMaterial>>().Setup(x => x.Provider).Returns(dataTest.Provider);
            dbSet.As<IQueryable<BookMaterial>>().Setup(x => x.Expression).Returns(dataTest.Expression);
            dbSet.As<IQueryable<BookMaterial>>().Setup(x => x.ElementType).Returns(dataTest.ElementType);
            dbSet.As<IQueryable<BookMaterial>>().Setup(x => x.GetEnumerator()).Returns(dataTest.GetEnumerator());

            dbSet.As<IAsyncEnumerable<BookMaterial>>()
                .Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<BookMaterial>(dataTest.GetEnumerator()));

            dbSet.As<IQueryable<BookMaterial>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<BookMaterial>(dataTest.Provider));

            var context = new Mock<BookContext>();
            context.Setup(x => x.Books).Returns(dbSet.Object);
            return context;

        }

        [Fact]
        public async void GetBookById()
        {
            var mockContext = CreateContext();
            var mockmapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingTest())).CreateMapper();

            var request = new GetBookById.Query(Guid.Empty);

            var handler = new GetBookById.Handler(mockContext.Object, mockmapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(result);
        }

        [Fact]
        public async void GetAllBook()
        {
            var mockContext = CreateContext();
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingTest())).CreateMapper();

            var getAllBooksHandler = new StoreServices.Api.Book.Application.Handler(mockContext.Object, mockMapper);
            var query = new GetAllBooks();

            var result = await getAllBooksHandler.Handle(query, new System.Threading.CancellationToken());

            Assert.True(result.Any());

        }

        [Fact]
        public async void CreateBook()
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "DbBookFake")
                .Options;

            var context = new BookContext(options);

            var request = new CreateBook.CreateBookRequest(new BookMaterial { Tittle = "Test", BookAuthor = Guid.Empty, PublicationDate = DateTime.Now});
            var handler = new CreateBook.Handler(context);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(result);
        }
    }
}