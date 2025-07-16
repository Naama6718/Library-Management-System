using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2
{
    [Flags]
    public enum BookCategory
    {
        NA = 0,       //00000000// 
        Thriller = 1,        //00000001// מותחן
        Biography = 2,       //00000010// בביאוגרפיה
        Adult = 4,           //00000100// מבוגרים
        History = 8,         //00001000// היסטוריה
        Children = 16,      //00010000// ילדים
        YoungAdult = 32

    }
}
