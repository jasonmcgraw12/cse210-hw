class AnimatedArmor : Enemy
{
    public AnimatedArmor(): base(
        "Animated Armor"
        , 2
        , 25
        , 25
        , new List<Attack>(){new Slash()}
        , new Dictionary<Item, double>(){{new Sword(), 0.2}, {new ChainArmor(), 0.5}}){}
}