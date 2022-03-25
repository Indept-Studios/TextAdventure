using System;

namespace TextAdventure
{
    public class Shop
    {
        private static int armorPower;
        private static int diffficultyValue;
        private static int potionPower;
        private static int weaponPower;

        public static void RunShop(Creature player)
        {
            armorPower = 100 * (player.armorValue + 1); ;
            diffficultyValue = 25 + (10 * player.difficulty);
            potionPower = 25 + (10 * player.difficulty);
            weaponPower = 100 * (player.weaponValue + 1);

            ShopGUI(player);

            while (true)
            {
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.A:
                        TryBuy("armor", armorPower, player);
                        break;
                    case ConsoleKey.D:
                        TryBuy("difficulty", diffficultyValue, player);
                        break;
                    case ConsoleKey.P:
                        TryBuy("potion", potionPower, player);
                        break;
                    case ConsoleKey.W:
                        TryBuy("weapon", weaponPower, player);
                        break;
                    case ConsoleKey.E:
                        break;
                    case ConsoleKey.Q:
                        Program.Quit();
                        break;
                    default:
                        break;
                }
            }

        }

        private static void TryBuy(string item, int cost, Creature player)
        {
            if (player.coins >= cost)
            {
                switch (item)
                {
                    case "armor":
                        player.armorValue++;
                        break;
                    case "difficulty":
                        player.difficulty++;
                        break;
                    case "potion":
                        player.potion++;
                        break;
                    case "weapon":
                        player.weaponValue++;
                        break;
                    default:
                        break;
                }
                player.coins -= cost;
            }
            else
            {
                Console.WriteLine("You don´t have enough coins! come back later");
                Console.WriteLine("Press any Key...");
                Console.ReadKey();
            }
        }

        private static void ShopGUI(Creature player)
        {
            Console.Clear();
            Console.WriteLine("====     Shop    ====");
            Console.WriteLine("=====================");
            Console.WriteLine("| (A)rmor: $        |" + armorPower);
            Console.WriteLine("| (D)ifficulty Mod  |" + diffficultyValue);
            Console.WriteLine("| (P)otion: $       |" + potionPower);
            Console.WriteLine("| (W)eapon: $       |" + weaponPower);
            Console.WriteLine("=====================");
            Console.WriteLine("| (E)xit            |");
            Console.WriteLine("| (Q)uit Game       |");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==== PlayerStats ====");
            Console.WriteLine("=====================");
            Console.WriteLine("| Armor:         | " + player.armorValue);
            Console.WriteLine("| Difficulty Mod | " + player.difficulty);
            Console.WriteLine("| Potion:        | " + player.potion);
            Console.WriteLine("| Weapon:        | " + player.weaponValue);
            Console.WriteLine("| Coins:         | " + player.coins);
            Console.WriteLine("=====================");
            Console.WriteLine("What do u want to buy?");
        }
    }
}
