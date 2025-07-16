using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2.Flyweight_design
{
    public class BookFactory
    {
        private static Dictionary<string, BaseBook> _books = new Dictionary<string, BaseBook>();

        public BookFactory()
        {
            
        }
        public  BaseBook GetBook(string name, string author, BookCategory category)
        {
            string key = $"{name}_{author}_{category}";

            if (!_books.ContainsKey(key))
            {
                _books[key] = new BaseBook(name, author, category);
            }
            else _books[key].Copies += 1;

                return _books[key];
        }
    }

}
