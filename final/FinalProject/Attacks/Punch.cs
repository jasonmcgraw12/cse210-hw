class Punch : Attack
{
    public Punch() : base(
        "punch"
        , "strength"
        , new List<string>(){"slaped"}
        , 0
        , new List<int>(){1, 2}){}
}