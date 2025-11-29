class Room
{
    string _title;
    string _description;
    List<Enemy> _enemies = new();
    List<Enemy> _dyingEnemies = new();
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

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void SetDyingEnemy(Enemy enemy)
    {
        _dyingEnemies.Add(enemy);
    }

    public Player GetPlayer()
    {
        return _player;
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

    public Dictionary<string, Enemy> DisplayEnemies()
    {
        int i = 1;
        Dictionary<string, Enemy> enemyDict = new();
        foreach (Enemy enemy in _enemies)
        {
            enemy.CheckDeath(this);
        }
        RemoveEnemies();
        foreach (Enemy enemy in _enemies)
            {
                Console.Write($"{i}. ");
                enemyDict[i.ToString()] = enemy;
                enemy.Display();
                i++;
            }
        return enemyDict;
    }

    public void ContinueCombat(Player player)
    {
        string input = null;
        bool didPerformAction = false;
        foreach (Enemy enemy in _enemies)
        {
            enemy.AttackPlayer(player);
        }
        Console.WriteLine($"Enemies in {_title}");
        DisplayEnemies();
        while(!didPerformAction) // change, this while loop so that you can break out of it if all enemies are dead after you attacked.
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
                Attack attack = player.DisplayAttacks();
                Dictionary<string, Enemy> enemyDict = DisplayEnemies();
                input = Printer.WriteRead("(Enter the corrisponding number of the enemy you want to target.)");

                Enemy target = null;
                if (enemyDict.ContainsKey(input))
                {
                    target = enemyDict[input];
                    didPerformAction = true;
                }
                else
                {
                    Printer.PrintError("The number you inputed doesn't match an enemy. there's no behavior for this");
                }
                player.MakeAttack(attack, target);
                Console.Clear();
                DisplayEnemies();
            }
        }
        // player turn here
        // foreach (Enemy enemy in _enemies)
        // {
        //     enemy.CheckDeath(this); // WARNING can probably combine this with the top foreach loop
        // }
        // foreach (Enemy enemy in _enemies)
        // {
        //     enemy.AttackPlayer(player);
        // }
    }

    public void RemoveEnemies()
    {
        foreach (Enemy dyingEnemy in _dyingEnemies)
        {
            _enemies.Remove(dyingEnemy);
        }
        _dyingEnemies.Clear();
    }

    public void Test()
    {
        _challenge.Start(_player);
    }
}