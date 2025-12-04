class StatCheck
{
    private bool _didSucceed = false;
    private string _beginningDescription;
    private string _failDescription;
    private string _successDescripton;
    private string _challengedStat;
    private int _challengeAmount;
    private List<Item> _rewards;

    public StatCheck(string beginningDescription, string failDescription, string successDescription, string challengedstat, int challengeAmount, List<Item> rewards)
    {
        _beginningDescription = beginningDescription;
        _successDescripton = successDescription;
        _failDescription = failDescription;
        _challengedStat = challengedstat;
        _challengeAmount = challengeAmount;
        _rewards = rewards;
    }

    public bool GetSuccess()
    {
        return _didSucceed;
    }

    public virtual void Start(Player player)
    {
        Random rnd = new();
        string input = "";
        while (input.ToLower() != "yes" && input.ToLower() != "no")
        {
            input = Printer.ChallengeWriteRead(_beginningDescription);
            // if (input.ToLower() != "yes" && input.ToLower() != "no")
            // {
            //     Printer.PauseInput("(Please enter 'yes' or 'no' in the next section to decide what to do)");
            // }
            if (input.ToLower() == "yes")
            {
                int modifier = player.GetStat(_challengedStat)/2;
                int numberRolled = rnd.Next(modifier); // inputs 0 to max stat (a base of 4 or 5 on start)
                if (numberRolled >= _challengeAmount)
                {
                    _didSucceed = true;
                    Printer.PauseInput(_successDescripton);
                    foreach (Item reward in _rewards)
                    {
                        player.AddToInventory(reward);
                        Console.WriteLine($"You got {reward}");
                    }
                    Printer.PauseInput("");
                    
                }
                else
                {
                    Printer.PauseInput(_failDescription);
                }
            }
            else if (input.ToLower() == "no")
            {
                Printer.PauseInput("You decide it's best to move on.");
            }
        }
    }
}