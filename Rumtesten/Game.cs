using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TextAdventure
{
    class Game
    {
        public static int WIDTH { get; private set; } = 20;
        public static int HEIGHT { get; private set; } = 10;
        public static Random rnd { get; private set; }
        public static int Difficulty { get; set; } = 1;
        public static Player CurrentPlayer { get; set; }
        public static Map map { get; set; }

        public Game()
        {
            Initilalisation();
           
            CurrentPlayer = Load(out bool newP);
            if (newP)
                Encounters.FirstEncounter();

            do
            {
                Console.Clear();
                map.DrawMap(CurrentPlayer);
                CurrentPlayer.Move(map);
            } while (true);
        }

        private void Initilalisation()
        {
            try
            {
                Directory.CreateDirectory("saves");
            }
            catch (Exception)
            {
                //Errorhandling
            }

            rnd = new Random();
            map = new Map(HEIGHT, WIDTH);
        }

        private Player NewStart(int id)
        {
            Console.Clear();
            Player player = new Player();
            Console.WriteLine("Brawl Dungeon!");
            Console.WriteLine("Please enter your name");
            player.Name = Console.ReadLine();
            player.ID = id;
            Console.Clear();
            Console.WriteLine("You awake in a cold, stone, dark room. You feel dazed and are having trouble remebering");
            Console.WriteLine("anything about your past.");

            if (player.Name == "")
                Console.WriteLine("You can´t even remember your own name...");
            else
                Console.WriteLine("You know your name is " + player.Name);

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You are walking through the darkness when you feel a door handle. When you turn it the door opens.");
            return player;
        }

        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }

        public static void DeletePlayer()
        {
            File.Delete("saves/" + CurrentPlayer.ID.ToString());
        }

        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + CurrentPlayer.ID.ToString();
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, CurrentPlayer);
            file.Close();
        }

        private Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string path in paths)
            {
                FileStream file = File.Open(path, FileMode.Open);
                Player player = (Player)binForm.Deserialize(file);
                file.Close();
                players.Add(player);
            }
            idCount = players.Count;


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose your player");

                foreach (Creature player in players)
                {
                    Console.WriteLine(player.ID + ": " + player.Name);
                }
                Console.WriteLine("Please input player name oder id (id:# or playername). Additionally, 'create' will start a new save!");
                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if (data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach (Player player in players)
                            {
                                if (player.ID == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("There is no player with that id!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Your id needs to be a number! Press any key to continue!");
                            Console.ReadKey();
                        }
                    }
                    else if (data[0] == "create")
                    {
                        Player newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;
                    }
                    else
                    {
                        foreach (Player player in players)
                        {
                            if (player.Name == data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("There is no player with that name!");
                        Console.ReadKey();
                    }
                }

                catch (IndexOutOfRangeException)
                {

                    Console.WriteLine("Your id needs to be a number! Press any key to continue!");
                    Console.ReadKey();
                }
            }
        }

    }
}
