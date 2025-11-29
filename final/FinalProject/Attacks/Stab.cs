class Stab : Attack
{
    public Stab() : base(
        "stab"
        , "dexterity"
        , new List<string>(){"stabed", "jabed", "pierced"}
        , 3
        , new List<int>(){1, 4}){}
}