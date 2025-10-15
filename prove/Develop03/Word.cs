class Word()
{
    private string _word;



    public Word(string word) : this()
    {
        _word = word;
    }

    
    public void Hide()
    {

    }


    public void Show()
    {

    }


    public bool IsHidden()
    {
        return false;
    }
    

    public string GetRenderText()
    {
        return _word;
    }
}