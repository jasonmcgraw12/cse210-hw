class Mimic : Enemy
{
    public Mimic() : base (
        "mimic"
        , 3
        , 40
        , 40
        , new(){new Chomp()}
        , new(){{new Sword(),0.5}, {new Sword(),0.1}, {new Coin(20),1.0}}
    ){}
}