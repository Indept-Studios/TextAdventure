using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Function
    {
        public static void TypeLine(string line, int duration = 100)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                System.Threading.Thread.Sleep(duration); // Sleep for 150 milliseconds
            }
            Console.WriteLine();
        }
    }
}
