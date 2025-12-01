class PoisonedLair : Room
{//string title, string description, List<Enemy> enemies, StatCheck challenge, Action<Player> bossRoomEffect
    public PoisonedLair(int level) : base (
        "Poisoned Lair"
        , "Poisoned smoke stings your loungs"
        , new List<Enemy>(){new Goblin()}
        , new StatCheck(
            "Would you like to pick the lock?"
            , "You take an hour trying to figure out the lock, \"Tell you what, just leave me here and find someone else to pick the lock.\""
            , $"You pick the lock. The shop keeper gives you {5*level} coins and shows you his wares."
            , "dexterity"
            , 2+level
            , new List<Item>(){new Coin(5*level)}
        )
    )
    {
        Action<Player> roomEffect = (player) =>
        {
            Random rnd = new();
            int poisonDamage = -rnd.Next(1,player.GetLevel());
            player.SetHealth(poisonDamage);
            Printer.PauseInput($"The poison in the room deals {poisonDamage}");
        };
        SetRoomEffect(roomEffect);
    }
}