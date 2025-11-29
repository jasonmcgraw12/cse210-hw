class GoblinNest : Room
{
    public GoblinNest(int level) : base(
        "A Hideout for Goblins"
        , "You walk in on a pack of goblins having a family dinner."
        , new List<Enemy>(){new Goblin()}
        , new StatCheck(
        "Would you like to grab the leftover food?"
        , ""
        , "You grab the dead goblins' food."
        , "dexterity"
        , 0
        , new List<Item>(){new Food("steak", 1, 10, 20)}
        )
    )
    {
        for (int i = 0; i < level; i++)
        {
            AddEnemy(new Goblin());
        }
    }
}