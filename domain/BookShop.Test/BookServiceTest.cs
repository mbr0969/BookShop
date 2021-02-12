using Moq;
using Xunit;

namespace BookShop.Test {
    public class BookServiceTest {

        [Fact]
        public void GetAllByQueryWithIsbn_CallsGetAllByIsbn() {

            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                                        .Returns(new[] {new Book(1,"","",""), } );

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                                        .Returns(new[] { new Book(2, "", "", ""), });

            BookService bookService = new BookService(bookRepositoryStub.Object);
            var validIsbn = "ISBN 12345-6789 1";
            var actual = bookService.GetAllByQuery(validIsbn);
            Assert.Collection(actual, book => Assert.Equal(1,book.Id));
        }

        [Fact]
        public void GetAllByQueryWithAuthor_CallsGetAllByTitleOrAuthor() {

            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", ""), });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", ""), });

            BookService bookService = new BookService(bookRepositoryStub.Object);
            var invalidIsbn = "12345-6789 1";
            var actual = bookService.GetAllByQuery(invalidIsbn);
            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }



    }
}
