using System;
using static System.Console;


namespace TextAdventure
{
    public class Encounters
    {
        /// <summary>
        /// Intro Encounter
        /// </summary>
        public static void FirstEncounter()
        {
            WriteLine("Behind the door is a room with a table and two chairs.");
            WriteLine("A candle burns on the table and a human villain sits there and eats.");
            WriteLine("You grab a wooden stick leaning against the door and start fighting");
            Combat(false, new Monster() { Name = "Human Villain", WeaponValue = 1, Health = 4 });
        }

        private static void BasicFightEncounter()
        {
            WriteLine("Basic Fight Story");
            Combat(true, new Monster());
        }

        private static void WizardEncounter()
        {
            WriteLine("Wizard Fight Story");
            Combat(false, new Monster() { Name = "Wizzard", WeaponValue = 3, Health = 5 });
        }

        private static void BossEncounter()
        {
            WriteLine("Boss Fight Story");
            Combat(false, new Monster() { Name = "Chris", WeaponValue = 5, Health = 25 });
        }

        /// <summary>
        /// Include BasicEncounter, WizardEncounter, BossEncounter
        /// </summary>
        public static void RandomEncounter()
        {
            switch (Game.rnd.Next(0, 3))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    WizardEncounter();
                    break;
                case 2:
                    BasicFightEncounter();
                    //BossEncounter();
                    break;
            }
        }

        /// <summary>
        /// Combat
        /// </summary>
        /// <param name="random">True for random Monster, false for fixed Monster</param>
        /// <param name="monster"></param>
        private static void Combat(bool random, Monster monster)
        {
            string monsterName = "";
            int monsterPower = 0;
            int monsterHealth = 0;
            int monsterDamage;
            int monaterAttack;
            int potionValue;

            if (random)
            {
                monsterPower = monster.SetDamageValue();
                monsterHealth = monster.SetHealthValue();
            }
            else
            {
                monsterName = monster.Name;
                monsterPower = monster.WeaponValue;
                monsterHealth = monster.Health;
            }

            while (monsterHealth > 0)
            {
                Console.WriteLine("Please press any key to continue");
                ReadKey();
                Clear();
                WriteLine(monsterName);
                WriteLine($"Power: {monsterPower} / Health: {monsterHealth}");
                WriteLine("====================");
                WriteLine("|(A)ttack (D)efend |");
                WriteLine("|(R)un    (H)eal   |");
                WriteLine("|(S)hop   (Q)uit   |");
                WriteLine("====================");
                WriteLine($"Potions: {Game.CurrentPlayer.Potions} Health: {Game.CurrentPlayer.Health}");
                string input = ReadLine();

                switch (input.ToLower())
                {
                    case "a":
                        WriteLine("You attack " + monsterName + " with a good punch");
                        monsterDamage = monsterPower - Game.CurrentPlayer.ArmorValue;
                        if (monsterDamage < 0)
                            monsterDamage = 0;
                        monaterAttack = Game.rnd.Next(0, Game.CurrentPlayer.WeaponValue) + Game.rnd.Next(1, 4);
                        WriteLine("You lose " + monsterDamage + " health and deal " + monaterAttack + " damage");
                        Game.CurrentPlayer.Health -= monsterDamage;
                        monsterHealth -= monaterAttack;
                        break;
                    case "d":
                        WriteLine("You defend yourself against " + monsterName + " and parry his attack");
                        monsterDamage = (monsterPower / 4) - Game.CurrentPlayer.ArmorValue;
                        if (monsterDamage < 0)
                            monsterDamage = 0;
                        monaterAttack = Game.rnd.Next(0, Game.CurrentPlayer.WeaponValue) / 2;
                        WriteLine("You lose " + monsterDamage + " health and deal " + monaterAttack + " damage");
                        Game.CurrentPlayer.Health -= monsterDamage;
                        monsterHealth -= monaterAttack;
                        break;
                    case "r":
                        if (Game.rnd.Next(0, 2) == 0)
                        {
                            WriteLine("You try to run away but you can't shake off the attacker");
                            monsterDamage = monsterPower - Game.CurrentPlayer.ArmorValue;
                            if (monsterDamage < 0)
                                monsterDamage = 0;
                            WriteLine("You lose " + monsterDamage + " health, unable to escape");
                            Game.CurrentPlayer.Health -= monsterDamage;
                        }
                        else
                        {
                            WriteLine("You run away and after a short time have shaken off your pursuer");

                        }
                        break;
                    case "h":
                        if (Game.CurrentPlayer.Potions == 0)
                        {
                            WriteLine("Heal failed because u have no potions left!");
                            monsterDamage = monsterPower - Game.CurrentPlayer.ArmorValue;
                            if (monsterDamage < 0)
                                monsterDamage = 0;
                            WriteLine(monsterDamage + " dmg from " + monsterName);
                            Game.CurrentPlayer.Health -= monsterDamage;
                        }
                        else
                        {
                            WriteLine("Heal success");
                            potionValue = 5;
                            WriteLine("You gain " + potionValue + " health");
                            Game.CurrentPlayer.Health += potionValue;
                            Game.CurrentPlayer.Potions--;
                            monsterDamage = (monsterPower / 4) - Game.CurrentPlayer.ArmorValue;
                            if (monsterDamage < 0)
                                monsterDamage = 0;
                            WriteLine(monsterDamage + " dmg from " + monsterName);
                            Game.CurrentPlayer.Health -= monsterDamage;
                        }
                        break;
                    case "s":
                        if (Game.rnd.Next(0, 2) == 0)
                        {
                            WriteLine("You try to escape to a nearby shop, but do not escape your pursuer");
                            monsterDamage = monsterPower - Game.CurrentPlayer.ArmorValue;
                            if (monsterDamage < 0)
                                monsterDamage = 0;
                            WriteLine("You lose " + monsterDamage + " health, unable to escape");
                            Game.CurrentPlayer.Health -= monsterDamage;
                        }
                        else
                        {
                            WriteLine("You do a few hooks and get away from your pursuer");
                            Shop.RunShop();
                        }
                        break;
                    case "q":
                        Game.Quit();
                        break;

                    default:
                        break;
                }

               
                //check for loot
                if (Game.CurrentPlayer.Health > 0 && monsterHealth <= 0)
                {
                    int c = monster.SetCoinsValue();
                    WriteLine("You have defeated " + monsterName + "! Glory will be yours forever. You will also find " + c + " coins ");
                    Game.CurrentPlayer.Coins += c;
                }


                //check for player death
                else if (Game.CurrentPlayer.Health <= 0)
                {
                    WriteLine("You died. It seems that your opponent was too strong for you. Maybe someday a hero will come to defeat them all");
                    Game.DeletePlayer();
                    Environment.Exit(0);
                }
            }
            ReadKey();
        }
    }
}