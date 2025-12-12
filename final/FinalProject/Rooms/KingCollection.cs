class KingCollection : Room
{
    public KingCollection(int level) : base(
        "King's Collection"
        , "You feel like royalty walking in this room. A giant red carpet and armor stands welcome you... Until you get too close."
        , new List<Enemy>(){new AnimatedArmor()}
        , new StatCheck(
        "The armor must have been protecting something. Would you like to look around the room?"
        , "You don't find anything in this room, so you decide to move on to the next."
        , "You find treasure under the rug!"
        , "intelligence"
        , 5
        , new List<Item>(){new Coin(10*level)}
        )
    )
    {
        for (int i = 0; i < Math.Floor(level/2.0)-1; i++)
        {
            AddEnemy(new AnimatedArmor());
        }
    }
}