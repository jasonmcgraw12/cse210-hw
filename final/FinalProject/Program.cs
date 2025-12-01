using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
// What is an interface in C#?
class Program
{
    static void Main(string[] args)
    {
        string input = "";
        string fileName;
        int roomNumber = 0;
        
        Console.WriteLine("Welcome to a text dungeon adventure!");
        Player player = new("name",50,10,10,10,10); // CHANGE could easily make different "classes" by starting the player with different gear and stats
        List<Func<Room>> beginningRooms = new()
        {
            () => new Cave(player.GetLevel())
        };
        List<Func<Room>> shopRooms = new()
        {
            () => new CagedShop(player.GetLevel())
        };
        List<Func<Room>> rooms = new()
        {
            () => new Vault(player.GetLevel())
            // , () => new GoblinNest(player.GetLevel())
        };
        List<Func<Room>> bossRooms = new()
        {
            () => new PoisonedLair(player.GetLevel())
        };


        // Item apple = new Food("apple",1,1,2);
        // player.AddToInventory(apple);
        // Axe axe = new Axe();
        // player.AddToInventory(axe);
        // Armor shield = new("shield",1,3);
        // player.AddToInventory(shield);
        

        while (input != "4")
        {
            player.LevelUp();
            input = Printer.WriteRead("""
            What would you like to do?
            1. Check inventory
            2. Check stats
            3. Move forward in dungeon
            4. Save and exit
            """);
            if (input == "1")
            {
                player.DisplayInventory();
            }
            else if (input == "2")
            {
                player.DisplayStats();
            }
            else if (input == "3")
            {
                Room room = GetRandomRoom(player);
                player.EnterRoom(room);
                roomNumber++;
            }
            else if (input == "4")
            {
                Console.WriteLine($"See you later {player}!");
            }
        }

        Room GetRandomRoom(Player player)
        {
            int level = player.GetLevel();
            Random rnd = new();
            if (roomNumber == 0)
            {
                int i = rnd.Next(beginningRooms.Count());
                Room createdRoom = CreateRoom(beginningRooms, i);
                return createdRoom;
            }
            else if (roomNumber % 10 == 0)
            {
                int i = rnd.Next(bossRooms.Count());
                Room createdRoom = CreateRoom(bossRooms, i);
                return createdRoom;
            }
            else if (roomNumber % 5 == 0)
            {
                int i = rnd.Next(shopRooms.Count());
                Room createdRoom = CreateRoom(shopRooms, i);
                return createdRoom;
            }
            else
            {
                int i = rnd.Next(rooms.Count());
                Room createdRoom = CreateRoom(rooms, i);
                return createdRoom;
            }
            // string compilerPath = AppContext.BaseDirectory;
            // string path = compilerPath+"../../../";
            // string[] roomFiles = Directory.GetFiles(path);
        }

        Room CreateRoom(List<Func<Room>> roomFactories, int i)
        {
            Func<Room> factory = roomFactories[i];
            return factory();
        }

        // // Enemy goblin = new Goblin();
        // // goblin.Display();

        // Room room = new Vault();
        // player.EnterRoom(room);

        // Room room1 = new GoblinNest();
        // player.EnterRoom(room1);
        


        // // using copilot to help with converting Json file into an enemy
        // // Read JSON file
        // string json = File.ReadAllText("enemies.json");

        // // Convert JSON → EnemyData object
        // EnemyData goblinData = JsonSerializer.Deserialize<EnemyData>(json);
        // // Convert AttackData → Attack
        // Attack stabAttack = new Attack(goblinData.attacks.attackName);

        // // Convert lootTable (string,double) → Dictionary<Item,double>
        // Dictionary<Item, double> loot = new();
        // foreach (var kvp in goblinData.lootTable)
        // {
        //     Item item = new Item(kvp.Key); // assuming Item(string name) constructor
        //     loot[item] = double.Parse(kvp.Value);
        // }

        // Enemy goblin = new Enemy(
        //     goblinData.enemyName,
        //     goblinData.enemyHealth,
        //     goblinData.enemyHealth, // currentHealth starts full
        //     new List<Attack> { stabAttack },
        //     loot
        // );

        // // copilot code ends here

        // LoadGoalFile();




        void LoadGoalFile()
        {
            Console.Clear();
            input = "";
            Dictionary<string, string> numToFileName= new();
            while (!numToFileName.ContainsKey(input))
            {
                Console.Clear();
                Console.WriteLine("What goal file do you want to load?");
                string path = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
                string[] files = Directory.GetFiles(path+"\\GoalFiles");
                numToFileName = new();
                int index = 1;
                foreach(string file in files)
                {
                    string fileName = file.Replace(path+"\\GoalFiles\\","");
                    numToFileName[index.ToString()] = fileName;
                    Console.WriteLine($"{index}. {fileName}");
                    index++;
                }
                Console.WriteLine($"{index}. New file");
                input = Console.ReadLine();
                if (numToFileName.ContainsKey(input))
                {
                    fileName = numToFileName[input];// CHANGE make LoadGoals for this project
                    // LoadGoals(path+"\\GoalFiles\\"+numToFileName[input]);
                }
                else if (input == index.ToString())
                {
                    Console.WriteLine("What would you like to name your file?");
                    input = Console.ReadLine();
                    fileName = input;
                    SaveGoals(fileName);// put info to be saved here
                }
            }       
        }

        // void LoadGoals(string path)
        // {
        //     List<string> lines = new();
        //     bool isOnFirstLine = true;
        //     goals.Clear();
        //     foreach (string line in File.ReadLines(path))
        //     {
        //         if (isOnFirstLine)
        //         {
        //             string[] parts = line.Split("||");
        //             totalPoints = int.Parse(parts[0]);
        //             level = int.Parse(parts[1]);
        //             isOnFirstLine = false;
        //         }
        //         else
        //         {
        //             string[] parts = line.Split("||");
        //             bool isComplete = bool.Parse(parts[2]);
        //             string goalTitle = parts[3];
        //             string goalDescription = parts[4];
        //             int goalPoints = int.Parse(parts[5]);
        //             if (parts[0] == "SimpleGoal")
        //             {
        //                 SimpleGoal simpleGoal = new SimpleGoal(isComplete, goalPoints, goalTitle, goalDescription);
        //                 goals.Add(simpleGoal);
                        
        //             }
        //             else if (parts[0] == "EternalGoal")
        //             {
        //                 SimpleGoal simpleGoal = new EternalGoal(isComplete, goalPoints, goalTitle, goalDescription);
        //                 goals.Add(simpleGoal);
        //             }
        //             else if (parts[0] == "NumberedGoal")
        //             {
        //                 int completionPoints = int.Parse(parts[6]);
        //                 int currentChecks = int.Parse(parts[7]);
        //                 int maxChecks = int.Parse(parts[8]);
        //                 SimpleGoal simpleGoal = new NumberedGoal(isComplete, goalPoints, completionPoints, currentChecks, maxChecks, goalTitle, goalDescription);
        //                 goals.Add(simpleGoal);
        //             }
        //             else{Console.WriteLine($"ERROR: {parts[0]} does not equal one of the given types");}
        //             lines.Add(line);
        //         }
        //     }
        //     SaveGoals(fileName, totalPoints, level, goals);
        // }

        static void SaveGoals(string fileName)//, int totalPoints, int level, List<SimpleGoal> goals)
        {
            string path = Environment.CurrentDirectory+"\\GoalFiles\\";
            if (Environment.CurrentDirectory == AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.Length - 1))
            {
                path = "..\\..\\..\\GoalFiles\\";
            }
            using (StreamWriter outputFile = new StreamWriter(path + fileName, append: false))
            {
                // outputFile.WriteLine(totalPoints+$"||{level}");
                // foreach (SimpleGoal goal in goals)
                // {
                //     outputFile.WriteLine(goal.GetInfo());
                // }
            }
        }
    }
}