using System.Security.Cryptography.X509Certificates;

class Scripture()
{
    private List<Word> _words;
    private string _sentances;
    private List<int> _hiddenIndexes;



    public Scripture(string sentances, List<int> hiddenIndexes) : this()
    {
        _hiddenIndexes = hiddenIndexes;
        _words = new();
        _sentances = sentances;
        string strippedSentances = sentances;
        string[] words = strippedSentances.Split(" ");
        foreach (string word in words)
        {
            Word word1 = new(word);
            _words.Add(word1);
        }
    }
    

    public string HideWords()
    {
        string hiddenSentances = "";
        int wordIndex = 0;
        foreach (Word word in _words)
        {
            foreach (int index in _hiddenIndexes)
            {
                word.Show();
                if (index == wordIndex)
                {
                    word.Hide();
                    break;
                }
            }
            string wordName = word.GetRenderText();
            List<string> shownWords = [];
            hiddenSentances += wordName + " ";
            wordIndex++;
        }
        return hiddenSentances;
    }


    public void SetHiddenIndexes(List<int> ints)
    {
        _hiddenIndexes = ints;
    }


    public List<int> GetHiddenIndexes()
    {
        return _hiddenIndexes;
    }


    public List<Word> GetWords()
    {
        return _words;
    }


    public string GetRenderedText()
    {
        return "";
    }


    public bool IsCompletlyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}