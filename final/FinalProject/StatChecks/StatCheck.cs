class StatCheck
{
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

    public void Start(Player player)
    {
        string input;
        input = Printer.ChallengeWriteRead(_beginningDescription);
        if (input.ToLower() == "yes")
        {
            int stat = player.GetStat(_challengedStat);
            if (stat > _challengeAmount)
            {
                Printer.PauseInput("You succeeded! "+ _successDescripton);
                foreach (Item reward in _rewards)
                {
                    player.AddToInventory(reward);
                }
                
            }
            else
            {
                Printer.PauseInput("You failed. "+ _failDescription);
            }
        }
    }
}