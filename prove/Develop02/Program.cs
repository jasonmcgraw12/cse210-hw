using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Journal currentJournal = new();
        string input = "";
        do
        {
            Console.WriteLine("""
            What would you like to do today?
            1. write entry
            2. display current journal
            3. save journal
            4. load past journal
            5. burn journal
            6. end
            """);
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Entry entry = new();
                    entry._date = DateTime.Now.ToString("m/d/yyyy");
                    entry._prompt = GetNewPrompt();
                    Console.WriteLine(entry._prompt);
                    entry._responce = Console.ReadLine();
                    currentJournal._entries.Add(entry);
                    // if (currentJournal._name == "")
                    // {
                    //     Console.WriteLine("You're not writing on a file, if this is intended press enter, otherwise input the name of the file here:");
                    //     input = Console.ReadLine();
                    //     if (input != "")
                    //     {
                    //         currentJournal = CreateJournal(input);
                    //         currentJournal.Write(entry);
                    //     }
                    // }
                    // else
                    // {

                    //     currentJournal.Write(entry);
                    // }

                    break;
                case "2":
                    currentJournal.Display();
                    break;
                case "3":
                    Console.WriteLine("What would you like to name the file you'll save your journal entries to?");
                    input = Console.ReadLine();
                    currentJournal = SaveJournal(currentJournal, input);
                    break;
                case "4":
                    Console.WriteLine("what is the name of the file you'd like to load?");
                    input = Console.ReadLine();
                    currentJournal = LoadJournal(input);
                    // journal.Display();
                    break;
                case "5":
                    Console.WriteLine("what is the name of the file you want to burn?");
                    input = Console.ReadLine();
                    BurnFile(input);
                    break;
                case "6":
                    input = "end";
                    break;
            }

        }
        while (input != "end");
    }


    static Journal SaveJournal(Journal currentJournal, string journalName)
    {
        currentJournal._name = journalName;
        string directory = Directory.GetCurrentDirectory();
        string path = directory + "\\Journals\\" + journalName + ".txt";
        using (FileStream fs = File.Create(path)) { }
        currentJournal.Write();
        return currentJournal;
    }


    static Journal LoadJournal(string journalName)
    {
        Journal journal = new();
        journal._name = journalName;
        // find journal you want to write on
        string directory = Directory.GetCurrentDirectory();
        string path = directory + "\\Journals\\" + journalName + ".txt";
        // Console.WriteLine("you are in the directory: " + Directory.GetCurrentDirectory() + path);
        if (File.Exists(path))
        {
            foreach (string line in File.ReadLines(path))
            {
                Entry entry = new();
                string[] parts = line.Split("|");
                entry._date = parts[0];
                entry._prompt = parts[1];
                entry._responce = parts[2];
                journal._entries.Add(entry);
            }
            // journal.Display();
        }
        else
        {
            Console.WriteLine("That journal doesn't exist. Select save journal to make a new journal.");
        }
        return journal; // CONTINUE make a journal attach to a file, delete journal and show file.
    }

    static string GetNewPrompt()
    {
        List<String> prompts = ["What was the best part of your day?"
                                , "What was challenging about your day? And how did you work through it (or how are you going to work through it)?"
                                , "How are you feeling currently, and what caused you to feel that way?"
                                , "Who was the most interesting person I interacted with today?"
                                , "What was the best part of my day?"
                                , "How did I see the hand of the Lord in my life today?"
                                , "What was the strongest emotion I felt today?"
                                , "If I had one thing I could do over today, what would it be?"
        ];
        Random random = new();
        int index = random.Next(prompts.Count);
        // Console.WriteLine(index);
        return prompts[index];
    }


    static void BurnFile(string journalName)
    {
        string directory = Directory.GetCurrentDirectory();
        string path = directory + "\\Journals\\" + journalName + ".txt";
        Journal journal = LoadJournal(journalName);
        journal.Display();
        if (File.Exists(path))
        {
            File.Delete(path);
            Console.WriteLine("File deleted successfully.");
        }

        journal._entries = [];
        journal._name = "";
    }
}