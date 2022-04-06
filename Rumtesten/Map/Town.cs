using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Town
    {
        public int X { get; set; } = 4;
        public int Y { get; set; } = 9;
        public string Sym { get; set; } = "T";


        public Town(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void RunShop()
        {
            string input = "";
            do
            {
                Console.Clear();
                Console.WriteLine("========     Shop     ========");
                Console.WriteLine("==============================");
                Console.WriteLine("||  Buy (A)rmor:            ||");
                Console.WriteLine("||  Buy (W)eapon:           ||");
                Console.WriteLine("||  Buy (P)otion:           ||");
                Console.WriteLine("==============================");
                Console.WriteLine("||  Get 1 (H)ealth Point    ||");
                Console.WriteLine("||  Get 1 (D)amage Point    ||");
                Console.WriteLine("==============================");
                Console.WriteLine("======== Player Stats ========");
                Console.WriteLine("==============================");
                Console.WriteLine("||  Armor:                  ||");
                Console.WriteLine("||  Weapon:                 ||");
                Console.WriteLine("||  Health:                 ||");
                Console.WriteLine("||  Damage:                 ||");
                Console.WriteLine("||  Potions:                ||");
                Console.WriteLine("||  Coins:                  ||");
                Console.WriteLine("==============================");
                Console.WriteLine("========    Action    ========");
                Console.WriteLine("==============================");
                Console.WriteLine("||  (E)xit                  ||");
                Console.WriteLine("||  (Q)uit Game             ||");
                Console.WriteLine("==============================");
                Console.WriteLine("==============================");
                Console.WriteLine();
                Console.WriteLine("   What, do you want to do?   ");
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "a":
                    case "w":
                    case "p":
                    case "h":
                    case "d":
                    case "e":
                    case "q":

                    default:
                        Console.WriteLine("Please only enter one letter from the ");
                        break;
                }

            } while (true);
        }

        public bool Trybuy()
        {
            return false;
        }
    }
}
