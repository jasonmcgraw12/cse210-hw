class Word
{
    private string _word;
    private string _hiddenWord;
    private string _shownWord;


    public Word(string word)
    {
        _shownWord = word;
        _word = word;
    }

    
    public void Hide()
    {
        string hashes = "";
        foreach (char letter in _word) // CHANGE to only do this to some words, then replace wordName with some of the words.
        {
            hashes += "-";
        }
        _hiddenWord = hashes;
        _shownWord = _hiddenWord;
    }


    public void Show()
    {
        _shownWord = _word;
    }


    public bool IsHidden()
    {
        if (_shownWord == _hiddenWord)
        {
            return true;
        }
        return false;
    }
    

    public string GetRenderText()
    {
        return _shownWord;
    }
}