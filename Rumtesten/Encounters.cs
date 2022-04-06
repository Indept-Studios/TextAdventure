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
            string name = "";
            int power = 0;
            int health = 0;

            if (random)
            {
                name = GetName();
                power = monster.SetDamageValue();
                health = monster.SetHealthValue();
            }
            else
            {
                name = monster.Name;
                power = monster.WeaponValue;
                health = monster.Health;
            }

            while (health > 0)
            {
                ReadKey();
                Clear();
                WriteLine(name);
                WriteLine(power + "/" + health);
                WriteLine("====================");
                WriteLine("|(A)ttack (D)efend |");
                WriteLine("|(R)un    (H)eal   |");
                WriteLine("|(S)hop   (Q)uit   |");
                WriteLine("====================");
                WriteLine("Potions: " + Game.CurrentPlayer.Potions + "    Health: " + Game.CurrentPlayer.Health);
                string input = ReadLine();

                //attack
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    WriteLine("You attack " + name + " with a good punch");
                    int damage = power - Game.CurrentPlayer.ArmorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = Game.rnd.Next(0, Game.CurrentPlayer.WeaponValue) + Game.rnd.Next(1, 4);
                    WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Game.CurrentPlayer.Health -= damage;
                    health -= attack;
                }

                //defend
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    WriteLine("You defend yourself against " + name + " and parry his attack");
                    int damage = (power / 4) - Game.CurrentPlayer.ArmorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = Game.rnd.Next(0, Game.CurrentPlayer.WeaponValue) / 2;
                    WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Game.CurrentPlayer.Health -= damage;
                    health -= attack;
                }

                //run
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    if (Game.rnd.Next(0, 2) == 0)
                    {
                        WriteLine("You try to run away but you can't shake off the attacker");
                        int damage = power - Game.CurrentPlayer.ArmorValue;
                        if (damage < 0)
                            damage = 0;
                        WriteLine("You lose " + damage + " health, unable to escape");
                        Game.CurrentPlayer.Health -= damage;
                    }
                    else
                    {
                        WriteLine("You run away and after a short time have shaken off your pursuer");

                    }
                }

                //heal
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    if (Game.CurrentPlayer.Potions == 0)
                    {
                        WriteLine("Heal failed because u have no potions left!");
                        int damage = power - Game.CurrentPlayer.ArmorValue;
                        if (damage < 0)
                            damage = 0;
                        WriteLine(damage + " dmg from " + name);
                        Game.CurrentPlayer.Health -= damage;
                    }
                    else
                    {
                        WriteLine("Heal success");
                        int potionV = 5;
                        WriteLine("You gain " + potionV + " health");
                        Game.CurrentPlayer.Health += potionV;
                        Game.CurrentPlayer.Potions--;
                        int damage = (power / 4) - Game.CurrentPlayer.ArmorValue;
                        if (damage < 0)
                            damage = 0;
                        WriteLine(damage + " dmg from " + name);
                        Game.CurrentPlayer.Health -= damage;
                    }
                }

                //shop
                else if (input.ToLower() == "s" || input.ToLower() == "shop")
                {

                    if (Game.rnd.Next(0, 2) == 0)
                    {
                        WriteLine("You try to escape to a nearby shop, but do not escape your pursuer");
                        int damage = power - Game.CurrentPlayer.ArmorValue;
                        if (damage < 0)
                            damage = 0;
                        WriteLine("You lose " + damage + " health, unable to escape");
                        Game.CurrentPlayer.Health -= damage;
                    }
                    else
                    {
                        WriteLine("You do a few hooks and get away from your pursuer");
                        Shop.RunShop();
                    }
                }

                //quit
                else if (input.ToLower() == "q" || input.ToLower() == "quit")
                {
                    Game.Quit();
                }


                //check for loot
                if (Game.CurrentPlayer.Health > 0 && health <= 0)
                {
                    int c = monster.SetCoinsValue();
                    WriteLine("You have defeated " + name + "! Glory will be yours forever. You will also find " + c + " coins ");
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

        private static string GetName()
        {
            switch (Game.rnd.Next(0, 4))
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