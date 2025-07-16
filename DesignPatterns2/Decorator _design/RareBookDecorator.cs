using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2.Decorator__design
{
    public class RareBookDecorator : BookDecorator
    {
        public RareBookDecorator(Book book) : base(book) { }

        public override void PrintBookDecorator(int num)
        {
             book.PrintDetailsOfBook(num);
            Console.WriteLine("Rare Book!");
                
        }


    }
}
