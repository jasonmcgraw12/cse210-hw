class Vault : Room
{
    public Vault() : base(
        "Vault Room"
        , "A large locked door stands in your path. There are scratches by the lock from when a previous adventurer tried to get in."
        , new List<Enemy>()
        , new StatCheck(
            "Would you like to pick the lock?"
            , "You take an hour trying to figure out the lock, but you decide it's time to move on."
            , "You pick the lock and open the door to the spoils."
            , "dexterity"
            , 15
            , new List<Item>(){new Coin(15)}
        )
    ){}
}