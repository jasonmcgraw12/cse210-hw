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
                    Console.WriteLine($"Your total points is currently {totalPoints}! (press enter to continue)");
                    Console.ReadLine();
                    // bool isOnFirstLine = true;
                    // string path = Environment.CurrentDirectory+"\\GoalFiles\\";
                    // if (Environment.CurrentDirectory == AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.Length - 1))
                    // {
                    //     path = "..\\..\\..\\GoalFiles\\";
                    // }
                    // foreach (string line in File.ReadLines(path+fileName))
                    // {
                    //     if (isOnFirstLine)
                    //     {
                    //         totalPoints = int.Parse(line);
                    //         isOnFirstLine = false;
                    //     }
                    // }
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
            while(input != "5" && input != "4" && input != "3" && input != "2" && input != "1")
            {
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
                        // add SimpleGoal1 to file save system
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
                    case "4":
                        Console.WriteLine("Going back...");
                        break;
                }
            }
            SaveGoals(fileName, totalPoints, goals);
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
                    Console.WriteLine($"Your total points is now at {totalPoints}! (press enter to continue)");
                    Console.ReadLine();
                }
                SaveGoals(fileName, totalPoints, goals);
            }
        }
        
        static void SaveGoals(string fileName, int totalPoints, List<SimpleGoal> goals)
        {
            string path = Environment.CurrentDirectory+"\\GoalFiles\\";
            if (Environment.CurrentDirectory == AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.Length - 1))
            {
                path = "..\\..\\..\\GoalFiles\\";
            }
            using (StreamWriter outputFile = new StreamWriter(path + fileName, append: false))
            {
                outputFile.WriteLine(totalPoints);
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
                    totalPoints = int.Parse(line);
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
                        
                        // add SimpleGoal1 to file save system
                    }
                    else if (parts[0] == "EternalGoal")
                    {
                        SimpleGoal simpleGoal = new EternalGoal(isComplete, goalPoints, goalTitle, goalDescription);
                        goals.Add(simpleGoal);
                        // add SimpleGoal1 to file save system
                    }
                    else if (parts[0] == "NumberedGoal")
                    {
                        int completionPoints = int.Parse(parts[6]);
                        int currentChecks = int.Parse(parts[7]);
                        int maxChecks = int.Parse(parts[8]);
                        SimpleGoal simpleGoal = new NumberedGoal(isComplete, goalPoints, completionPoints, currentChecks, maxChecks, goalTitle, goalDescription);
                        goals.Add(simpleGoal);
                        // add SimpleGoal1 to file save system
                    }
                    else{Console.WriteLine($"ERROR: {parts[0]} does not equal one of the given types");}
                    // CHANGE search through the strings and make corisponding goals
                    lines.Add(line);
                }
            }
            SaveGoals(fileName, totalPoints, goals);
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
                    SaveGoals(input, totalPoints, goals);
                }
            }           
        }
        // Console.WriteLine("Hello Develop05 World!");
        // SimpleGoal mySimpleGoal = new SimpleGoal(50,"Make goal","make a goal program");
        // mySimpleGoal.Display();
        // mySimpleGoal.Complete();
        // mySimpleGoal.Display();

        // EternalGoal myEternalGoal = new(10,"Get up in the morning","Wake up each morning with a positive attitude");
        // myEternalGoal.Complete();
        // myEternalGoal.Display();

        // NumberedGoal myNumberedGoal = new(10,200,2,"work on project","work on this project for 15 minutes");
        // myNumberedGoal.Display();
        // myNumberedGoal.Complete();
        // myNumberedGoal.Complete();
        // myNumberedGoal.Display();
    }
}