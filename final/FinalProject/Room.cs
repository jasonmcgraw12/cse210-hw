class Room
{
    string _title;
    string _description;
    List<Enemy> _enemies = new();
    StatCheck challenge;
    // List<Contraption> contraptions = new();
    // CHANGE the above commented code to include interactables like chests or traps.

    Room(string title, string description, List<Enemy> enemies)
    {
        _title = title;
        _description = description;
        _enemies = enemies;
    }
}