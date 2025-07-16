using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2.Bridge_design
{
   public class DisplayColor 
    {
        public void ApplyColorBackGround(string color)
        {
     

            switch (color)
            {
                case "Blue":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case "Red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case "Green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                default:
                    return;
                   
            }
        }

        public void ApplyColorText(string color)
        {


            switch (color)
            {
                case "Blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    return;

            }
        }
    }
}
