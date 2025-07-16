using DesignPatterns2.Decorator__design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2.Proxy_design
{
    public class ProxyBookService : IBookService
    {
        private RealBookService _realBookService;

        public ProxyBookService(Library library)
        {
            _realBookService = new RealBookService(library);
        }

        public void DisplayBookInfo(int bookId)
        {
            _realBookService.DisplayBookInfo(bookId);
        }

        public bool IsItCanBorrowed(int bookId)
        {
            var book = _realBookService._library.ReturnBookById(bookId);
            if (book == null)
            {
                Console.WriteLine("Book not found");
                return false;
            }

            // אם הספר הוא נדיר ויש למשתמש הרשאות, תמשיך
            if (_realBookService._library.IsSpecialBook(bookId) && !User.HasPermission)
            {
                Console.WriteLine("You are not allowed to lend rare books!");
                return false;
            }

            return true;
        }

    }

}
