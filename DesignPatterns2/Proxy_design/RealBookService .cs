using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2.Proxy_design
{
    public class RealBookService : IBookService
    {
        public Library _library;

        public RealBookService(Library library)
        {
            _library = library;
        }

        public void DisplayBookInfo(int bookId)
        {
            var book = _library.ReturnBookById(bookId);
            if (book != null)
            {
                Console.WriteLine($" name: {book.baseBook.Name}, auther: {book.baseBook.Author}, category: {book.baseBook.Category}");
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }

        public bool IsItCanBorrowed(int bookId)
        {
            Book book = _library.ReturnBookById(bookId);
            return book.Borrow();
        }


    }

}
