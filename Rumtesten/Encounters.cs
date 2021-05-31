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
            WriteLine("Behind the door is a room with a table and 2 chairs.");
            WriteLine("A candle burns on the table and a human villain sits there and eats.");
            WriteLine("You grab a wooden stick leaning against the door and start fighting");
            Combat(false, "test", 1, 4);
        }
                
        private static void BasicFightEncounter()
        {
            WriteLine("Basic Fight Story");
            Combat(true, "", 0, 0);
        }
                
        private static void WizardEncounter()
        {
            WriteLine("Wizard Fight Story");
            Combat(false, "Wizzard", 3, 5);
        }
               
        private static void BossEncounter()
        {
            WriteLine("Boss Fight Story");
            Combat(false, "Chris", 5, 25);
        }

        // Tools

        /// <summary>
        /// Include BasicEncounter, WizardEncounter, BossEncounter
        /// </summary>
        public static void RandomEncounter()
        {
            switch (Program.rnd.Next(0, 3))
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
        /// Start a combat, random means random or fixed opponent
        /// </summary>
        /// <param name="random"></param>
        /// <param name="name"></param>
        /// <param name="power"></param>
        /// <param name="health"></param>
        private static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;


            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }

            while (h > 0)
            {
                ReadKey();
                Clear();
                WriteLine(n);
                WriteLine(p + "/" + h);
                WriteLine("====================");
                WriteLine("|(A)ttack (D)efend |");
                WriteLine("|(R)un    (H)eal   |");
                WriteLine("|(S)hop   (Q)uit   |");
                WriteLine("====================");
                WriteLine("Potions: " + Program.currentPlayer.potion + "    Health: " + Program.currentPlayer.health);
                string input = ReadLine();

                //attack
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    WriteLine("You attack " + n + " with a good punch");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = Program.rnd.Next(0, Program.currentPlayer.weaponValue) + Program.rnd.Next(1, 4);
                    WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }

                //defend
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    WriteLine("You defend yourself against " + n + " and parry his attack");
                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = Program.rnd.Next(0, Program.currentPlayer.weaponValue) / 2;
                    WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }

                //run
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    if (Program.rnd.Next(0, 2) == 0)
                    {
                        WriteLine("You try to run away but you can't shake off the attacker");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        WriteLine("You lose " + damage + " health, unable to escape");
                        Program.currentPlayer.health -= damage;
                    }
                    else
                    {
                        WriteLine("You run away and after a short time have shaken off your pursuer");

                    }
                }

                //heal
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    if (Program.currentPlayer.potion == 0)
                    {
                        WriteLine("Heal failed because u have no potions left!");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        WriteLine(damage + " dmg from " + n);
                        Program.currentPlayer.health -= damage;
                    }
                    else
                    {
                        WriteLine("Heal success");
                        int potionV = 5;
                        WriteLine("You gain " + potionV + " health");
                        Program.currentPlayer.health += potionV;
                        Program.currentPlayer.potion--;
                        int damage = (p / 4) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        WriteLine(damage + " dmg from " + n);
                        Program.currentPlayer.health -= damage;
                    }
                }

                //shop
                else if (input.ToLower() == "s" || input.ToLower() == "shop")
                {

                    if (Program.rnd.Next(0, 2) == 0)
                    {
                        WriteLine("You try to escape to a nearby shop, but do not escape your pursuer");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        WriteLine("You lose " + damage + " health, unable to escape");
                        Program.currentPlayer.health -= damage;
                    }
                    else
                    {
                        WriteLine("You do a few hooks and get away from your pursuer");
                        Shop.RunShop(Program.currentPlayer);
                    }
                }

                //quit
                else if (input.ToLower() == "q" || input.ToLower() == "quit")
                {
                    Program.Quit();
                }
                    

                //check for loot
                if (Program.currentPlayer.health > 0 && h <= 0)
                {
                    int c = Program.currentPlayer.GetCoins();
                    WriteLine("You have defeated " + n + "! Glory will be yours forever. You will also find " + c + " coins ");
                    Program.currentPlayer.coins += c;
                }


                //check for player death
                else if (Program.currentPlayer.health <= 0)
                {
                    WriteLine("You died. It seems that your opponent was too strong for you. Maybe someday a hero will come to defeat them all");
                    Program.DeletePlayer();
                    Environment.Exit(0);
                }
            }
            ReadKey();
        }

        private static string GetName()
        {
            switch (Program.rnd.Next(0, 4))
            {
                case 0:
                    return "Skeleton";
                case 1:
                    return "Zombie";
                case 2:
                    return "Human Cultist";
                case 3:
                    return "Grave Robber";
            }
            return "Human Rouge";
        }
    }
}