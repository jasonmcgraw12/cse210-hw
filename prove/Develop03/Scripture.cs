using System.Security.Cryptography.X509Certificates;

class Scripture()
{
    private List<Word> _words;
    private string _sentances;



    public Scripture(string sentances) : this()
    {
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
        foreach (Word word in _words)
        {
            string wordName = word.GetRenderText();
            Console.WriteLine(wordName);
            string numHashes = "";
            foreach (char letter in wordName) // CHANGE to only do this to some words, then replace wordName with some of the words.
            {
                numHashes += "-";
            }
            hiddenSentances += wordName + " ";
        }
        return hiddenSentances;
    }


    public string GetRenderedText()
    {
        return "";
    }


    public bool IsCompletlyHidden()
    {
        return false;
    }
}