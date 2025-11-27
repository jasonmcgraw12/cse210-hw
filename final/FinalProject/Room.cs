class Room
{
    string _title;
    string _description;
    List<Enemy> _enemies = new();
    StatCheck _challenge;
    Player _player;
    // List<Contraption> contraptions = new();
    // CHANGE the above commented code to include interactables like chests or traps.

    public Room(string title, string description, List<Enemy> enemies, StatCheck challenge)
    {
        _title = title;
        _description = description;
        _enemies = enemies;
        _challenge = challenge;
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void Display()
    {
        Printer.PauseInput(_description);
        if (_challenge != null)
        {
            Test();
        }
    }

    public void Test()
    {
        _challenge.Start(_player);
    }
}