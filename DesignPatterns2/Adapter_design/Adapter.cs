// 📁 Adapter_design/Adapter.cs
using DesignPatterns2.Bridge_design;
using DesignPatterns2.Flyweight_design;
using System;

namespace DesignPatterns2.Adapter_design
{
    public class Adapter
    {
        private readonly DisplayColor _displayColor;

        public Adapter()
        {
            _displayColor = new DisplayColor();
        }

        public void Print(Book book, int num)
        {
            // קביעת צבע לפי קטגוריה
            string color = GetColorByCategory(book.baseBook.Category);

            // החלת הצבע
            if (num == 1)
                _displayColor.ApplyColorBackGround(color);
            else if (num == 2)
                _displayColor.ApplyColorText(color);
           Console.WriteLine($"Name :{book.baseBook.Name}\nAuthor :{book.baseBook.Author}\nCategory :{book.baseBook.Category}\nId :{book.Id}\nnum of copies:{book.baseBook.Copies}\nIsItBorrowed :{book.IsItBorrowed}\nBorrowingDate :{book.BorrowingDate}");

            // החזרת צבעי הקונסולה למצב המקורי
            Console.ResetColor();
        }

        private string GetColorByCategory(BookCategory bookCategory)
        {
            // נבדוק איזה קטגוריה נמצאת ראשון בערך השלם.
            if (bookCategory.HasFlag(BookCategory.Children))
                return "Red";  // ילדים
            if (bookCategory.HasFlag(BookCategory.Adult))
                return "Blue"; // מבוגרים
            if (bookCategory.HasFlag(BookCategory.YoungAdult))
                return "Green"; // נוער

            return "White"; // צבע ברירת מחדל
        }

    }
}
