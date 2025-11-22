using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string[] badges = ["Bronze", "Silver", "Gold"];
        int[] levelUpAt = [100,500];
        int level = 0;
        string input;
        string fileName = "";
        int totalPoints = 0;
        List<SimpleGoal> goals = new();
        LoadGoalFile();

        while(input != "5")
        {
            Console.Clear();
            Console.WriteLine(
                """
                what would you like to do?
                1. Make goal
                2. Record event
                3. Display score
                4. Load/create goal file
                5. End
                """);
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    MakeGoal();
                    break;
                case "2":
                    CompleteGoal();
                    break;
                case "3":
                    Console.WriteLine($"Your total points is currently at {totalPoints}! ");
                    Console.Write($"Your rank is {badges[level]}. ");
                    if (badges[level] != "Gold")
                    {
                        Console.Write($"in order to level up you need {levelUpAt[level]} total points. ");
                    }
                    else
                    {
                        Console.Write("You are at max level! ");
                    }
                    Console.WriteLine("(press enter to continue)");
                    Console.ReadLine();
                    break;
                case "4":
                    LoadGoalFile();
                    break;
                case "5":
                    Console.WriteLine("Ending the software... \n\nHave a great day!");
                    break;
            }
        }

        void MakeGoal()
        {
            input = "";
            Console.Clear();
            Console.WriteLine(
                """
            What kind of goal do you want to create? (enter '4' to end)
            1. Simple Goal
            2. Eternal Goal
            3. Numbered Goal
            4. End
            """);
            input = Console.ReadLine();
            bool iscomplete = false;
            switch (input)
            {
                case "1":
                    Console.WriteLine("What is the title of your goal?");
                    string goalTitle = Console.ReadLine();
                    Console.WriteLine("Descibe what the goal is.");
                    string goalDescription = Console.ReadLine();
                    Console.WriteLine("How many ponts should this goal give on completion?");
                    input = Console.ReadLine();
                    while (!int.TryParse(input, out int number))
                    {
                        Console.WriteLine("That isn't a correct input, please type in a number instead.");
                        input = Console.ReadLine();
                    }
                    int goalPoints = int.Parse(input);
                    SimpleGoal simpleGoal = new SimpleGoal(iscomplete, goalPoints, goalTitle, goalDescription);
                    goals.Add(simpleGoal);
                    break;
                case "2":
                    Console.WriteLine("What is the title of your goal?");
                    goalTitle = Console.ReadLine();
                    Console.WriteLine("Descibe what the goal is.");
                    goalDescription = Console.ReadLine();
                    Console.WriteLine("How many ponts should this goal give on completion?");
                    input = Console.ReadLine();
                    while (!int.TryParse(input, out int number))
                    {
                        Console.WriteLine("That isn't a correct input, please type in a number instead.");
                        input = Console.ReadLine();
                    }
                    goalPoints = int.Parse(input);
                    EternalGoal eternalGoal = new(iscomplete, goalPoints, goalTitle, goalDescription);
                    goals.Add(eternalGoal);
                    break;
                case "3":
                    Console.WriteLine("What is the title of your goal?");
                    goalTitle = Console.ReadLine();
                    Console.WriteLine("Descibe what the goal is.");
                    goalDescription = Console.ReadLine();
                    Console.WriteLine("How many ponts should this goal give on completion?");
                    input = Console.ReadLine();
                    while (!int.TryParse(input, out int number))
                    {
                        Console.WriteLine("That isn't a correct input, please type in a number instead.");
                        input = Console.ReadLine();
                    }
                    int completionPoints = int.Parse(input);
                    Console.WriteLine("How many ponts should this goal give when completing a part of it?");
                    input = Console.ReadLine();
                    while (!int.TryParse(input, out int number))
                    {
                        Console.WriteLine("That isn't a correct input, please type in a number instead.");
                        input = Console.ReadLine();
                    }
                    goalPoints = int.Parse(input);
                    Console.WriteLine("How many times should this goal be done before it's complete?");
                    input = Console.ReadLine();
                    while (!int.TryParse(input, out int number))
                    {
                        Console.WriteLine("That isn't a correct input, please type in a number instead.");
                        input = Console.ReadLine();
                    }
                    int maxChecks = int.Parse(input);
                    NumberedGoal numberedGoal = new(iscomplete, goalPoints, completionPoints, 0,  maxChecks, goalTitle, goalDescription);
                    goals.Add(numberedGoal);
                    break;
            }
            SaveGoals(fileName, totalPoints, level, goals);
        }

        void CompleteGoal()
        {
            Console.Clear();
            Dictionary<string, SimpleGoal> numToGoal = new();
            
            input = "";
            while (!numToGoal.ContainsKey(input))
            {
                int index = 1;
                Console.WriteLine("What goal would you like to complete?");
                foreach (SimpleGoal goal in goals)
                {
                    Console.Write($"{index}. ");
                    goal.Display();
                    numToGoal[index.ToString()] = goal;
                    index++;
                }
                numToGoal[index.ToString()] = null;
                input = Console.ReadLine();
            }
            if (numToGoal[input] != null)
            {
                int pointsRewarded = numToGoal[input].Complete();
                if (pointsRewarded == 0)
                {
                    Console.WriteLine("You've already completed that goal silly! (press enter to continue)");
                    Console.ReadLine();
                }
                else
                {
                    totalPoints += pointsRewarded;
                    Console.Write($"Your total points is now at {totalPoints}! ");
                    if (totalPoints >= levelUpAt[level])
                    {
                        if (badges[level] != badges[badges.Length-1])
                        {
                            level++;
                            Console.Write($"You leveled up! Your rank is now {badges[level]}. ");
                        }
                        Console.WriteLine("(press enter to continue)");
                    }
                    Console.ReadLine();
                }
                SaveGoals(fileName, totalPoints, level, goals);
            }
        }
        
        static void SaveGoals(string fileName, int totalPoints, int level, List<SimpleGoal> goals)
        {
            string path = Environment.CurrentDirectory+"\\GoalFiles\\";
            if (Environment.CurrentDirectory == AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.Length - 1))
            {
                path = "..\\..\\..\\GoalFiles\\";
            }
            using (StreamWriter outputFile = new StreamWriter(path + fileName, append: false))
            {
                outputFile.WriteLine(totalPoints+$"||{level}");
                foreach (SimpleGoal goal in goals)
                {
                    outputFile.WriteLine(goal.GetInfo());
                }
            }
        }

        void LoadGoals(string path)
        {
            List<string> lines = new();
            bool isOnFirstLine = true;
            goals.Clear();
            foreach (string line in File.ReadLines(path))
            {
                if (isOnFirstLine)
                {
                    string[] parts = line.Split("||");
                    totalPoints = int.Parse(parts[0]);
                    level = int.Parse(parts[1]);
                    isOnFirstLine = false;
                }
                else
                {
                    string[] parts = line.Split("||");
                    bool isComplete = bool.Parse(parts[2]);
                    string goalTitle = parts[3];
                    string goalDescription = parts[4];
                    int goalPoints = int.Parse(parts[5]);
                    if (parts[0] == "SimpleGoal")
                    {
                        SimpleGoal simpleGoal = new SimpleGoal(isComplete, goalPoints, goalTitle, goalDescription);
                        goals.Add(simpleGoal);
                        
                    }
                    else if (parts[0] == "EternalGoal")
                    {
                        SimpleGoal simpleGoal = new EternalGoal(isComplete, goalPoints, goalTitle, goalDescription);
                        goals.Add(simpleGoal);
                    }
                    else if (parts[0] == "NumberedGoal")
                    {
                        int completionPoints = int.Parse(parts[6]);
                        int currentChecks = int.Parse(parts[7]);
                        int maxChecks = int.Parse(parts[8]);
                        SimpleGoal simpleGoal = new NumberedGoal(isComplete, goalPoints, completionPoints, currentChecks, maxChecks, goalTitle, goalDescription);
                        goals.Add(simpleGoal);
                    }
                    else{Console.WriteLine($"ERROR: {parts[0]} does not equal one of the given types");}
                    lines.Add(line);
                }
            }
            SaveGoals(fileName, totalPoints, level, goals);
        }

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
                    fileName = numToFileName[input];
                    LoadGoals(path+"\\GoalFiles\\"+numToFileName[input]);
                }
                else if (input == index.ToString())
                {
                    Console.WriteLine("What would you like to name your file?");
                    input = Console.ReadLine();
                    fileName = input;
                    SaveGoals(fileName, totalPoints, level, goals);
                }
            }           
        }
    }
}