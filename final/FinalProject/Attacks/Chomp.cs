class Chomp : Attack
{
    public Chomp() : base(
        "chomp"
        , "strength"
        , new List<string>(){"chomped", "bit", "munched"}
        , 5
        , new List<int>(){5, 7}){}
}