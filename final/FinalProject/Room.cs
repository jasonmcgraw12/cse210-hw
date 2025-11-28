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

    public void Display(Player player)
    {
        Printer.PauseInput(_description);
        while (_enemies.Count != 0)
        {
            ContinueCombat(player);
        }
        if (_challenge != null)
        {
            Test();
        }
    }

    public void ContinueCombat(Player player)
    {
        string input = null;
        int i = 1;
        foreach (Enemy enemy in _enemies)
        {
            Console.Write($"{i}. ");
            if (i == 1)
            {
                enemy.Display();
            }
            else
            {
                Console.Write(", ");
                enemy.Display();
            }
            Console.WriteLine();
            i++;
        }
        while(input != "2")
        {
        input = Printer.WriteRead("""
        What would you like to do?
        1. Use/equip item
        2. Attack
        """);
        if (input == "1")
            {
                player.DisplayInventory();
            }
        else if (input == "2")
            {
                player.DisplayAttacks();
                Printer.PauseInput("");
                // CHANGE let user pick attack here
            }
        }
        // player turn here
        foreach (Enemy enemy in _enemies)
        {
            enemy.CheckDeath(this); // WARNING can probably combine this with the top foreach loop
        }
        foreach (Enemy enemy in _enemies)
        {
            enemy.AttackPlayer(player);
        }
    }

    public void RemoveEnemy(Enemy dyingEnemy)
    {
        _enemies.Remove(dyingEnemy);
        // foreach (Enemy enemy in _enemies)
        // {
        //     if (enemy == dyingEnemy)
        //     {
                
        //     }
        // }
    }

    public void Test()
    {
        _challenge.Start(_player);
    }
}