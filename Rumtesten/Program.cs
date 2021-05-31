using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;

namespace TextAdventure
{
    class Program
    {
        public static Creature currentPlayer = new Creature();
        public static bool mainLoop = true;
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            Directory.CreateDirectory("saves");

            currentPlayer = Load(out bool newP);

            if (newP)
                Encounters.FirstEncounter();

            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }
        }

        static Creature NewStart(int id)
        {
            Clear();
            Creature p = new Creature();
            WriteLine("Brawl Dungeon!");
            WriteLine("Please enter your name");
            p.name = ReadLine();
            p.id = id;
            Clear();
            WriteLine("You awake in a cold, stone, dark room. You feel dazed and are having trouble remebering");
            WriteLine("anything about your past.");

            if (p.name == "")
                WriteLine("You can´t even remember your own name...");
            else
                WriteLine("You know your name is " + p.name);

            ReadKey();
            Clear();
            WriteLine("You are walking through the darkness when you feel a door handle. When you turn it the door opens.");
            return p;
        }
        
        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }

        public static void DeletePlayer()
        {
            File.Delete("saves/" + currentPlayer.id.ToString());
        }

        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString();
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();
        }


        
        public static Creature Load(out bool newP)
        {
            newP = false;
            Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Creature> players = new List<Creature>();
            int idCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string path in paths)
            {
                FileStream file = File.Open(path, FileMode.Open);
                Creature player = (Creature)binForm.Deserialize(file);
                file.Close();
                players.Add(player);
            }
            idCount = players.Count;


            while (true)
            {
                Clear();
                WriteLine("Choose your player");

                foreach (Creature p in players)
                {
                    WriteLine(p.id + ": " + p.name);
                }
                WriteLine("Please input player name oder id (id:# or playername). Additionally, 'create' will start a new save!");
                string[] data = ReadLine().Split(':');

                try
                {
                    if (data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach (Creature player in players)
                            {
                                if (player.id == id)
                                {
                                    return player;
                                }
                            }
                            WriteLine("There is no player with that id!");
                            ReadKey();
                        }
                        else
                        {
                            WriteLine("Your id needs to be a number! Press any key to continue!");
                            ReadKey();
                        }
                    }
                    else if (data[0] == "create")
                    {
                        Creature newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;
                    }
                    else
                    {
                        foreach (Creature player in players)
                        {
                            if (player.name == data[0])
                            {
                                return player;
                            }
                        }
                        WriteLine("There is no player with that name!");
                        ReadKey();
                    }
                }

                catch (IndexOutOfRangeException)
                {

                    WriteLine("Your id needs to be a number! Press any key to continue!");
                    ReadKey();
                }
            }
        }
    }
}
