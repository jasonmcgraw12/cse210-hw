using System.Collections.Concurrent;

class Reference()
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;



    public Reference(string book, int chapter, int startVerse, int endVerse): this()
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    

    public string Display()
    {
        return "";
    }
}