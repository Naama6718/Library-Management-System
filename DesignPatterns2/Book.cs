using System.Drawing;
using DesignPatterns2.Adapter_design;
using DesignPatterns2.Flyweight_design;

namespace DesignPatterns2

{
   
    public class Book : IBook
    {

        public BaseBook baseBook { get; set; }
        public static int IdCode = 0;
        public int Id { get; set; }
      
        public bool IsItBorrowed { get; set; }
        public DateTime BorrowingDate { get; set; }
        BookFactory _bookFactory;

        public Book(string name, string author, BookCategory category)
        {
            Id = ++IdCode;
            IsItBorrowed = false;
            _bookFactory = new BookFactory();
            baseBook = _bookFactory.GetBook(name, author, category);

        }
      
        public void PrintDetailsOfBook(int num)
        {
            Adapter a = new Adapter();
            // הדפסת הספר
            Console.WriteLine($"Book: {this.baseBook.Name} by {this.baseBook.Author}");
            a.Print(this, num);
        }

        public bool Borrow()
        {
            if (IsItBorrowed)
                return false;
            IsItBorrowed = true;
            BorrowingDate = DateTime.Now;
            return true;
        }


        public bool Return()
        {
            if (!IsItBorrowed)
                return false;
            IsItBorrowed = false;
            return true;
        }

       
    }
}
