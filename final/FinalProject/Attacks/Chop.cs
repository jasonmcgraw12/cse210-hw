class Chop : Attack
{
    public Chop() : base(
        "chop"
        , "strength"
        , new List<string>(){"choped", "slashed", "cleaved"}
        , 5
        , new List<int>(){1, 6}){}
}