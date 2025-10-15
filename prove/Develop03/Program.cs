using System;

class Program
{
    static void Main(string[] args)
    {
        string input;
        bool isCompletlyHidden;
        do
        {
            string book = "Proverbs"; // CHANGE add a randomizer to pick these scriptures
            int chapter = 3;
            int startVerse = 5;
            int endVerse = 6;
            // WARNING the below string deleteMe is only a placeholder for the scripture words.
            string scriptureSentances = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
            Reference reference = new(book, chapter, startVerse, endVerse);
            Scripture scripture = new(scriptureSentances);
            Console.WriteLine(scripture.HideWords());
            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            input = Console.ReadLine();
            isCompletlyHidden = scripture.IsCompletlyHidden();
        }
        while (input != "quit" && !isCompletlyHidden);
    }
}