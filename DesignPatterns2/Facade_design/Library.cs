using DesignPatterns2.Composite_design;
using DesignPatterns2;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns2.Decorator__design;

public class Library
{
    private List<Category> BooksInLibrary = new List<Category>();
    private List<BookDecorator> SpecialBooks = new List<BookDecorator>(); // ספרים נדירים

    public void AddBook(Book b)
    {
        // מחפשים אם הקטגוריה כבר קיימת
        Category existingCategory = BooksInLibrary.FirstOrDefault(c => c.categoryName == b.baseBook.Category);

        if (existingCategory == null)
        {
            // אם הקטגוריה לא קיימת, ניצור קטגוריה חדשה
            existingCategory = new Category(b.baseBook.Category);
            BooksInLibrary.Add(existingCategory);
        }

        // הוספת הספר לקטגוריה המתאימה
        existingCategory.Books.Add(b);
    }

    public void AddSpecialBook(BookDecorator rareBook)
    {
        // הוספת ספר נדיר לרשימה נפרדת
        SpecialBooks.Add(rareBook);
    }

    public List<Book> GetBooksByCategory(BookCategory category)
    {
        Category foundCategory = BooksInLibrary.FirstOrDefault(c => c.categoryName == category);
        return foundCategory != null ? foundCategory.Books : new List<Book>();
    }

    public Book ReturnBookById(int bookId)
    {
        // חיפוש ספר נדיר
        BookDecorator rareBook = SpecialBooks.FirstOrDefault(rb => rb.book.Id == bookId);
        if (rareBook != null)
            return rareBook.book;
        // חיפוש ספר רגיל
        foreach (var category in BooksInLibrary)
        {
            Book foundBook = category.Books.FirstOrDefault(b => b.Id == bookId);
            if (foundBook != null)
                return foundBook;
        }

        return null;
    }

    public bool FindBookById(int bookId)
    {
        return BooksInLibrary.Any(c => c.Books.Any(b => b.Id == bookId)) || SpecialBooks.Any(rb => rb.book.Id == bookId);
    }

    public List<Book> GetAllBooks()
    {
        List<Book> allBooks = BooksInLibrary.SelectMany(c => c.Books).ToList();
        return allBooks;
    }
    public List<Book> GetAllSimpleBooks()
    {
        
        List<Book> allBooks = BooksInLibrary.SelectMany(c => c.Books).ToList();

        List<Book> booksNotInSpecialBooks = allBooks
            .Where(book => !SpecialBooks.Any(specialBook => specialBook.book.baseBook.Name.Equals(book.baseBook.Name)))
            .ToList();

        return booksNotInSpecialBooks;
    }


    public bool IsSpecialBook(int bookId)
    {
        return SpecialBooks.Any(rb => rb.book.Id == bookId);
    }
}
