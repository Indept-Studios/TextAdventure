using System;

namespace TextAdventure
{
    public class Shop
    {
        private static int armorPower;
        private static int diffficultyValue;
        private static int potionPower;
        private static int weaponPower;

        public static void RunShop()
        {
            armorPower = 100 * (Game.CurrentPlayer.ArmorValue + 1); ;
            diffficultyValue = 25 + (10 * Game.CurrentPlayer.Difficulty);
            potionPower = 25 + (10 * Game.CurrentPlayer.Difficulty);
            weaponPower = 100 * (Game.CurrentPlayer.WeaponValue + 1);
            bool shopIsRunning = true;


            while (shopIsRunning)
            {
                ShopGUI(Game.CurrentPlayer);
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.A:
                        TryBuy("armor", armorPower, Game.CurrentPlayer);
                        break;
                    case ConsoleKey.D:
                        TryBuy("difficulty", diffficultyValue, Game.CurrentPlayer);
                        break;
                    case ConsoleKey.P:
                        TryBuy("potion", potionPower, Game.CurrentPlayer);
                        break;
                    case ConsoleKey.W:
                        TryBuy("weapon", weaponPower, Game.CurrentPlayer);
                        break;
                    case ConsoleKey.E:
                        shopIsRunning = false;
                        break;
                    case ConsoleKey.Q:
                        Game.Quit();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void TryBuy(string item, int cost, Player player)
        {
            if (player.Coins >= cost)
            {
                switch (item)
                {
                    case "armor":
                        player.ArmorValue++;
                        break;
                    case "difficulty":
                        player.Difficulty++;
                        break;
                    case "potion":
                        player.Potions++;
                        break;
                    case "weapon":
                        player.WeaponValue++;
                        break;
                    default:
                        break;
                }
                player.Coins -= cost;
            }
            else
            {
                Console.WriteLine("You don´t have enough coins! come back later");
                Console.WriteLine("Press any Key...");
                Console.ReadKey();
            }
        }

        private static void ShopGUI(Player player)
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
            Console.WriteLine("=====================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==== PlayerStats ====");
            Console.WriteLine("=====================");
            Console.WriteLine("| Armor:         | " + player.ArmorValue);
            Console.WriteLine("| Difficulty Mod | " + player.Difficulty);
            Console.WriteLine("| Potion:        | " + player.Potions);
            Console.WriteLine("| Weapon:        | " + player.WeaponValue);
            Console.WriteLine("| Coins:         | " + player.Coins);
            Console.WriteLine("=====================");
            Console.WriteLine("What do u want to buy?");
        }
    }
}
