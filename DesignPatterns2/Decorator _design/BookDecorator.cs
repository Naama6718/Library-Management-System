using DesignPatterns2.Composite_design;
using DesignPatterns2.Proxy_design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2.Decorator__design
{
    public abstract class BookDecorator 
    {
        public Book book;

        public BookDecorator(Book book)
        {
            this.book = (Book)book;
        }


        public virtual bool Borrow()
        {
            return book.Borrow(); // שומר על ההתנהגות של השאלה
        }

        public virtual void PrintBookDecorator(int num)
        {
            if (User.HasPermission || IsRegularBook())
            {
                book.PrintDetailsOfBook(num);
            }
            else
            {
                Console.WriteLine("Access Denied: This book is only available for premium users.");
            }
        }
        private bool IsRegularBook()
        {
            return ((book.baseBook.Category & (BookCategory.Children | BookCategory.YoungAdult | BookCategory.Adult)) != 0);
        }

        public virtual bool Return()
        {
            return book.Return(); // שומר על ההתנהגות של החזרה
        }
   
    }

}
