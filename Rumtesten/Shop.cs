using static System.Console;

namespace TextAdventure
{
    public class Shop
    {
        public static void RunShop(Creature p)
        {
            int armorP;
            int diffP;
            int potionP;
            int weaponP;

            while (true)
            {
                armorP = 100 * (p.armorValue+1);
                diffP = 25 + 10 * p.difficulty;
                potionP = 25 + 10 * p.difficulty;
                weaponP = 100 * (p.weaponValue + 1);

                Clear();
                WriteLine("====     Shop    ====");
                WriteLine("=====================");
                WriteLine("| (A)rmor: $        |" + armorP);
                WriteLine("| (D)ifficulty Mod  |" + diffP);
                WriteLine("| (P)otion: $       |" + potionP);
                WriteLine("| (W)eapon: $       |" + weaponP);
                WriteLine("=====================");
                WriteLine("| (E)xit            |");
                WriteLine("| (Q)uit Game       |");
                WriteLine();
                WriteLine();
                WriteLine("==== PlayerStats ====");
                WriteLine("=====================");
                WriteLine("| Armor:         | " + p.armorValue);
                WriteLine("| Difficulty Mod | " + p.difficulty);
                WriteLine("| Potion:        | " + p.potion);
                WriteLine("| Weapon:        | " + p.weaponValue);
                WriteLine("| Coins:         | " + p.coins);
                WriteLine("=====================");
                WriteLine("What do u want to buy?");
                string input = ReadLine().ToLower();

                if (input == "a" || input == "armor")
                {
                    TryBuy("armor", armorP, p);
                }
                else if (input == "d" || input == "difficulty")
                {
                    TryBuy("difficulty", diffP, p);
                }
                else if (input == "p" || input == "potion")
                {
                    TryBuy("potion", potionP, p);
                }
                else if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponP, p);
                }
                else if(input == "e" || input == "exit")
                {
                    break;
                }
                else if (input == "q" || input == "quit")
                {
                    Program.Quit();
                }
            }
        }

        private static void TryBuy(string item, int cost, Creature p)
        {
            if (p.coins >= cost)
            {
                if (item == "armor")
                {
                    p.armorValue++;
                }
                else if (item == "difficulty")
                {
                    p.difficulty++;
                }
                else if (item == "potion")
                {
                    p.potion++;
                }
                else if (item == "weapon")
                {
                    p.weaponValue++;
                }
                p.coins -= cost;
            }
            else
            {
                WriteLine("You don´t have enough coins! come back later");
                ReadKey();
            }
        }
    }
}
