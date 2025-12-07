using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
// What is an interface in C#?
class Program
{
    static void Main(string[] args)
    {
        Player player = new("name",50,10,10,10,10); // CHANGE could easily make different "classes" by starting the player with different gear and stats
        string input = "";
        string fileName = LoadFile();
        int roomNumber = 0;
        // ClassFactory.MakeClass("Goblin");
        // LoadFile();
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
            , () => new GoblinNest(player.GetLevel())
        };
        List<Func<Room>> bossRooms = new()
        {
            () => new PoisonedLair(player.GetLevel())
        };
        
        Console.WriteLine("Welcome to a text dungeon adventure!");
        


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
            Save(fileName);
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
                // int i = rnd.Next(beginningRooms.Count());
                // Room createdRoom = CreateRoom(beginningRooms, i);
                // return createdRoom;
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




        string LoadFile()
        {
            Console.Clear();
            input = "";
            string fileName = "";
            Dictionary<string, string> numToFileName= new();
            while (!numToFileName.ContainsKey(input))
            {
                Console.Clear();
                Console.WriteLine("What goal file do you want to load?");
                string path = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
                string[] files = Directory.GetFiles(path+"\\SaveFiles");
                numToFileName = new();
                int index = 1;
                foreach(string file in files)
                {
                    fileName = file.Replace(path+"\\SaveFiles\\","");
                    numToFileName[index.ToString()] = fileName;
                    Console.WriteLine($"{index}. {fileName}");
                    index++;
                }
                Console.WriteLine($"{index}. New file");
                input = Console.ReadLine();
                if (numToFileName.ContainsKey(input))
                {
                    fileName = numToFileName[input];// CHANGE make Load for this project
                    // Load(path+"\\GoalFiles\\"+numToFileName[input]);
                }
                else if (input == index.ToString())
                {
                    input = "";
                    fileName = "";
                    while(input == "")
                    {
                        Console.WriteLine("What would you like to name your file?");
                        input = Console.ReadLine();
                        fileName = input;
                        if (input == "")
                        {
                            Printer.PauseInput("Please enter a name for your file.");
                        }
                    }
                    Save(fileName); // WARNING saving here might cause issues
                }
            }

            return fileName;
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
        //     Save(fileName, totalPoints, level, goals);
        // }

        void Save(string fileName)//, int totalPoints, int level, List<SimpleGoal> goals)
        {
            string path = Environment.CurrentDirectory+"\\SaveFiles\\";
            if (Environment.CurrentDirectory == AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.Length - 1))
            {
                path = "..\\..\\..\\SaveFiles\\";
            }
            using (StreamWriter outputFile = new StreamWriter(path + fileName, append: false))
            {
                // Player's general info
                // name, coins, xp, level, skillpoints, xpGoal, 
                outputFile.WriteLine(
                    $"{player.GetLevel()}||{player.GetMoney()}||{player.GetXP()}"
                    + $"||{player.GetLevel()}||{player.GetSkillPoints()}||XPGoal if used"
                    );
                
                // stats
                // health, currentHealth, strength, dexterity, intelligence, charisma
                outputFile.WriteLine(
                    $"{player.GetStat("health")}||{player.GetStat("currentHealth")}||{player.GetStat("strength")}||"
                    + $"{player.GetStat("dexterity")}||{player.GetStat("intelligence")}||{player.GetStat("charisma")}"
                    );
                
                // Equipped weapon and armor
                // Weapon
                string className = ClassFactory.GetClassName(player.GetWeapon().GetType());
                outputFile.WriteLine($"{className}");
                // Armor
                className = ClassFactory.GetClassName(player.GetArmor().GetType());
                outputFile.WriteLine($"{className}");

                // Player skills
                foreach (Skill skill in player.GetSkills())
                {
                    string skillName = ClassFactory.GetClassName(skill.GetType());
                    outputFile.Write($"{skillName}||");
                }
                outputFile.WriteLine();

                // Item in inventory
                foreach (Item item in player.GetItems())
                {
                    string itemName = ClassFactory.GetClassName(item.GetType());
                    outputFile.Write($"{itemName}:{item.GetNumber()}||");
                }
                // outputFile.WriteLine(totalPoints+$"||{level}");
                // foreach (SimpleGoal goal in goals)
                // {
                //     outputFile.WriteLine(goal.GetInfo());
                // }
            }
        }
    }
}