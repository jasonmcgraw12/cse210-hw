class Stab : Attack
{
    public Stab() : base(
        "stab"
        , "dexterity"
        , new List<string>(){"stab", "jab", "pierce"}
        , 3
        , new List<int>(){1, 4}){}
}