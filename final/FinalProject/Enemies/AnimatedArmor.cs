class AnimatedArmor : Enemy
{
    // string name, int health, int currenthealth, List<Attack> attacks, Dictionary<Item, double> lootTable
    // public Goblin()
    // {
    //     int health = 10;
    public AnimatedArmor(): base(
        "animated armor"
        , 2
        , 25
        , 25
        , new List<Attack>(){new Slash()}
        , new Dictionary<Item, double>(){{new Sword(), 0.2}, {new ChainArmor(), 0.5}}){}
    // }

    // private Goblin(string name, int health, List<Attack> attacks, Dictionary<Item, double> lootTable) : base(name, health, health, attacks, lootTable){}
}