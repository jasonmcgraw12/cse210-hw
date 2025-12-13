class Hoblin : Enemy
{
    public Hoblin(): base(
        "Hoblin"
        , 2
        , 20
        , 20
        , new List<Attack>(){new Stab()}
        , new Dictionary<Item, double>(){{new Dagger(), 0.4}, {new Coin(25), 1.0}, {new Steak(), 1.0}}){}
}