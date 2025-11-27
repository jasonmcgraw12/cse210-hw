class Goblin : Enemy
{
    // string name, int health, int currenthealth, List<Attack> attacks, Dictionary<Item, double> lootTable
    // public Goblin()
    // {
    //     int health = 10;
    public Goblin(): base(
        "goblin"
        , 10
        , 10
        , new List<Attack>(){new Stab()}
        , new Dictionary<Item, double>(){{new Dagger(), 0.1}, {new Coin(5), 1.0}}){}
    // }

    // private Goblin(string name, int health, List<Attack> attacks, Dictionary<Item, double> lootTable) : base(name, health, health, attacks, lootTable){}
}