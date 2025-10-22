using System.Collections.Concurrent;

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;



    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }


    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
    }


    public void Display()
    {
        string reference;
        if (_endVerse != 0)
        {
            reference = $"{_book} {_chapter}:{_startVerse}-{_endVerse}  ";
        }
        else
        {
            reference = $"{_book} {_chapter}:{_startVerse}  ";
        }
        Console.Write(reference);
    }
    

    public string GetReferenceString()
    {
        string reference;
        if (_endVerse != 0)
        {
            reference = $"{_book} {_chapter}:{_startVerse}-{_endVerse}  ";
        }
        else
        {
            reference = $"{_book} {_chapter}:{_startVerse}  ";
        }
        return reference;
    }
}