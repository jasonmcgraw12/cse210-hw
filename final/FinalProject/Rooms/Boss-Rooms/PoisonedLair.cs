class PoisonedLair : Room
{
    public PoisonedLair(int level) : base (
        "Poisoned Lair"
        , "Poisoned smoke stings your loungs"
        , new List<Enemy>(){new Goblin()}
        , null
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