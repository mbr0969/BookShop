
using System.Linq;

namespace BookShop.Memory  {
    public class BookRepository : IBookRepository {

        private readonly Book[] books = new[] { new Book(1, "Art of Programming","ISBN 12345-321456", "Mikle Djonson"), 
                                                                    new Book(2,"Refactoring","ISBN 36345-821456","Stolberg"), 
                                                                    new Book(3,"C Programming","ISBN 96345-542456","Riche"),  };

        public Book[] GetAllByIsbn(string isbn) {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }


        public Book[] GetAllByTitleOrAuthor(string query) {
            return books.Where(book => book.Title.Contains(query) || book.Author.Contains(query)).ToArray();
        }
    }
}
