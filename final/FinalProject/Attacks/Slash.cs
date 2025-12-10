class Slash : Attack
{
    public Slash() : base(
        "slash"
        , "dexterity"
        , new List<string>(){"slashed", "lacerated", "sliced"}
        , 5
        , new List<int>(){2, 7}){}
}