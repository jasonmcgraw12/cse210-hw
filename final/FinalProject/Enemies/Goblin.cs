class Goblin : Enemy
{
    public Goblin(): base(
        "Goblin"
        , 1
        , 10
        , 10
        , new List<Attack>(){new Stab()}
        , new Dictionary<Item, double>(){{new Dagger(), 0.4}, {new Coin(5), 1.0}}){}
}