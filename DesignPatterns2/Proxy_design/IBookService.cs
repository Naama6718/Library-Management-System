using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2.Proxy_design
{
    public interface IBookService
    {
        void DisplayBookInfo(int bookId);
        bool IsItCanBorrowed(int bookId);
    }

}
