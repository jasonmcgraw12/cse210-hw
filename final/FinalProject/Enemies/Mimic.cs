class Mimic : Enemy
{
    public Mimic() : base (
        "Mimic"
        , 3
        , 30
        , 30
        , new(){new Chomp()}
        , new(){{new Sword(),0.5}, {new Sword(),0.1}, {new Coin(20),1.0}}
    ){}
}