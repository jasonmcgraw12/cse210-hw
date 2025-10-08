using System.Runtime.InteropServices.Swift;
using System.IO;


class Journal()
{
    public string _name = "";
    public List<Entry> _entries = [];
    public List<String> _prompt = [];




    public void Write()
    {
        using (StreamWriter outputFile = new StreamWriter("Journals/" + _name + ".txt", append: true))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.Write(entry._date + "|");
                outputFile.Write(entry._prompt + "|");
                outputFile.WriteLine(entry._responce);
            }
            // outputFile.Write(newEntry._date + "|");
            // outputFile.Write(newEntry._prompt + "|");
            // outputFile.WriteLine(newEntry._responce);
        }
    }


    public void Display()
    {
        Console.WriteLine("==========");
        Console.WriteLine("Journal name: " + _name);
        foreach (Entry entry in _entries)
        {
            Console.WriteLine("----------");
            entry.Display();
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
        }

    }

    
}