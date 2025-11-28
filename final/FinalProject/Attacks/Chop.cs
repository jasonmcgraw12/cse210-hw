class Chop : Attack
{
    public Chop() : base(
        "chop"
        , "strength"
        , new List<string>(){"chop", "slash", "cleave"}
        , 5
        , new List<int>(){1, 6}){}
}