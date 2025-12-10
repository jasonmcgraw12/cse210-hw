class MimicRest : Room
{
    public MimicRest(int level) : base(
        "A room with a chest"
        , "You walk into a room with a beautiful chest."
        , new List<Enemy>(){}
        , null
    )
    {
        FailStatCheck check = new(
        "Would you like to open it?"
        , "You didn't notice that it's a mimic!"
        , "Based on your observations you identify the chest as a mimic. You carefully open the chest without waking it."
        , "intelligence"
        , 5
        , new List<Item>(){new Coin(20)}
        , this
        , (Room room) =>
        {
            room.AddEnemy(new Mimic());
        }
        );
        SetStatCheck(check);
    }
}