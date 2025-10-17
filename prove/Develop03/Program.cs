using System;

class Program
{
    static void Main(string[] args)
    {
        // Reference reference = null;
        // Scripture scripture = null;
        // Console.WriteLine("Would you like to memorise Proverbs 3:5-6? (yes/no) ");
        // string input = Console.ReadLine();
        // bool isCompletlyHidden;
        // string book; 
        // int chapter;
        // int startVerse;
        // int endVerse;
        // string scriptureSentances;
        // if (input == "yes")
        // {
        //     book = "Proverbs";
        //     chapter = 3;
        //     startVerse = 5;
        //     endVerse = 6;
        //     scriptureSentances = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        //     reference = new(book, chapter, startVerse, endVerse);
        //     scripture = new(scriptureSentances, []);        
        // }
        // else
        // {
        //     Console.WriteLine("Then you will memorize John 3:16!!! (press enter to continue)");
        //     Console.ReadLine();
        //     book = "John";
        //     chapter = 3;
        //     startVerse = 16;
        //     scriptureSentances = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        //     reference = new(book, chapter, startVerse);
        //     scripture = new(scriptureSentances, []);
        // }
        string input;
        bool isCompletlyHidden;
        ScriptureMastaries scriptureMastaries = new(1);
        KeyValuePair<Reference, string> referenceScripture = scriptureMastaries.GetReferenceAndScripture();
        Reference reference = referenceScripture.Key;
        Scripture scripture = new(referenceScripture.Value, []); // should change the [] to not exist and instead just make an empty instance in the scripture code, but I'm almost done and feeling lazy
        do
        {
            Console.Clear();
            reference.Display();
            Console.WriteLine(scripture.HideWords());
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish: ");
            input = Console.ReadLine();
            isCompletlyHidden = scripture.IsCompletlyHidden();
            List<int> currentIndexes = GetRandomWordIndexes(scripture.GetHiddenIndexes(), scripture.GetWords());
            scripture.SetHiddenIndexes(currentIndexes);
        }
        while (input != "quit" && !isCompletlyHidden);
    }


    public static List<int> GetRandomWordIndexes(List<int> currentIndexes, List<Word> words)
    {
        Random random = new();
        // check if current index is already full (no more words to hide), could also find all indexes not used
        currentIndexes.Sort();
        List<int> filledIndexes = new();
        List<int> notUsedIndexes = new();
        for (int i = 0; i != words.Count; i++)
        {
            filledIndexes.Add(i);
            bool isIndexThere = false;
            foreach (int index in currentIndexes)
            {
                if (index == i)
                {
                    isIndexThere = true;
                }
            }
            if (!isIndexThere)
            {
                notUsedIndexes.Add(i);
            }
        }
        if (notUsedIndexes.Count > 0)
        {
            int randomIndex = random.Next(notUsedIndexes.Count);
            currentIndexes.Add(notUsedIndexes[randomIndex]);
            // Console.WriteLine("index not full");
            // Console.WriteLine(string.Join(", ", filledIndexes));
        }
        // hides one word using the length of {words}
        return currentIndexes;
    }
}