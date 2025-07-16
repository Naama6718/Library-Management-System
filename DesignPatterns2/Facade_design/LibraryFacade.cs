//using DesignPatterns2.Composite_design;
using DesignPatterns2.Proxy_design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2.Facade_design
{
    public class LibraryFacade
    {
        private Library _library;
        private ProxyBookService ProxyBookService;

        public LibraryFacade(Library library)
        {
            _library =library;
            ProxyBookService = new ProxyBookService(_library);
        }

        //  השאלת ספר
        public bool BorrowBook(int bookId)
        {
            // מקבלים את הספר לפי ID
            Book book = _library.ReturnBookById(bookId);
            if (book == null)
            {
                Console.WriteLine("The book didn't find.");
                return false;
            }

            // בודקים אם הספר ניתן להשאלה
            if (!ProxyBookService.IsItCanBorrowed(bookId))
            {
                return false;  // הספר לא ניתן להשאלה
            }

            // בודקים אם הספר זמין להשאלה
            if (!IsBookAvailable(bookId))
            {
                Console.WriteLine("The book is already borrowed.");
                return false;
            }

            // אם כל התנאים מתקיימים
            book.IsItBorrowed = true;
            Console.WriteLine($"The book '{book.baseBook.Name}' borrowed successfully!");
            return true;
        }


        // 2️⃣ החזרת ספר
        public bool ReturnBook(int bookId)
        {
            Book book = _library.ReturnBookById(bookId);
            if (book == null)
            {
                Console.WriteLine(" the book didn't find.");
                return false;
            }

            if (book.Return())
            {
                Console.WriteLine($"the book '{book.baseBook.Name}' returned successfully!");
                return true;
            }
            else
            {
                Console.WriteLine(" The book was not borrowed..");
                return false;
            }
        }

        // 3️⃣ בדיקת זמינות ספר
        public bool IsBookAvailable(int bookId)
        {
            Book book = _library.ReturnBookById(bookId);
            if (book == null)
            {
                Console.WriteLine("The book is not found.");
                return false;
            }
            return !book.IsItBorrowed;  // מחזיר true אם הספר לא נלקח
        }


        // 4️⃣ הדפסת ספר לפי ID
        public void PrintBookById(int bookId,int num)
        {
            Book book = _library.ReturnBookById(bookId);
            if (book == null)
            {
                Console.WriteLine("The book is not found.");
                return;
            }
            book.PrintDetailsOfBook(num);
        }

        // 5️⃣ הדפסת ספרים בקטגוריה מסוימת
        public void PrintBooksByCategory(BookCategory category,int num)
        {
            var books = _library.GetBooksByCategory(category);
            if (!books.Any())
            {
                Console.WriteLine($" There are no books in the category. {category}.");
                return;
            }

            Console.WriteLine($" Books in category {category}:");
            foreach (var book in books)
            {
                book.PrintDetailsOfBook(num);
            }
        }
    }

}
