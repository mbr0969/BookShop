﻿
namespace BookShop {
    public interface IBookRepository {

        Book[] GetAllByTitleOrAuthor(string titleOrAuthor);
        Book[] GetAllByIsbn(string isbn);

    }
}
