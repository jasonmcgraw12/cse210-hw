class Cave : Room
{
    public Cave(int level) : base(
        "Cave Entrance"
        , "You arrive at a cave ready to start your day of adventure. The surface of the cave is covered in moss, and you can hear a trickling of water from within the cave."
        , new List<Enemy>()
        , new StatCheck(
            "Upon further inspection you see a skeleton in armor, likely a less fortuanate adventurer. Would you like to take their gear?"
            , "Out of respect for the dead you leave the skeleton alone."
            , "You grab the gear and continue into the cave."
            , "health"
            , 0
            , new List<Item>(){new Coin(3), new Axe(), new Ration(), new LeatherArmor()}
        )
    ){}
}