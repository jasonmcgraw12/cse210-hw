class StatCheck
{
    private string _beginningDescription;
    private string _failDescription;
    private string _successDescripton;
    private string _challengedStat;
    private int _challengeAmount;
    // Reward?

    StatCheck(string beginningDescription, string failDescription, string successDescription, string challengedstat, int challengeAmount)
    {
        _beginningDescription = beginningDescription;
        _successDescripton = successDescription;
        _failDescription = failDescription;
        _challengedStat = challengedstat;
        _challengeAmount = challengeAmount;
    }
}