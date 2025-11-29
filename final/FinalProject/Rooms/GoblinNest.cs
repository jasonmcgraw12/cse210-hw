class GoblinNest : Room
{
    public GoblinNest(int level) : base(
        "A Hideout for Goblins"
        , "You walk in on a pack of goblins having a family dinner."
        , new List<Enemy>(){new Goblin(), new Goblin()}
        , null
    // new StatCheck(
    //     "Would you like to pick the lock?"
    //     , "You take an hour trying to figure out the lock, but you decide it's time to move on."
    //     , "You pick the lock and open the door to the spoils."
    //     , "dexterity"
    //     , 15
    //     , new List<Item>(){new Coin(15)}
    // )
    )
    {
        for (int i = 0; i < level; i++)
        {
            AddEnemy(new Goblin());
        }
    }
}