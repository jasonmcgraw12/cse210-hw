class Room
{
    string _title;
    string _description;
    List<Enemy> _enemies = new();
    List<Enemy> _dyingEnemies = new();
    Action<Player> _roomEffect = null;
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

    public void SetRoomEffect(Action<Player> roomEffect)
    {
        _roomEffect = roomEffect;
    }

    public void SetStatCheck(StatCheck check)
    {
        _challenge = check;
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
    public virtual void Display(Player player)
    {
        Printer.PauseInput(_description);
        while (_enemies.Count != 0)
        {
            if (_roomEffect != null)
            {
                // roomEffect = (player) => { };
                _roomEffect(player); // this is for boss rooms, but I want it to take effect every round
            }
            
            ContinueCombat(player);
        }
        if (_challenge != null)
        {
            Test();// this uses the _player while the continue combat uses player from inheriting, change so they're the same
        }
        while (_enemies.Count != 0)
        {
            if (_roomEffect != null)
            {
                // roomEffect = (player) => { };
                _roomEffect(player); // this is for boss rooms, but I want it to take effect every round
            }
            
            ContinueCombat(player);
        }
    }

    public Dictionary<string, Enemy> DisplayEnemies()
    {
        int i = 1;
        Dictionary<string, Enemy> enemyDict = new();
        // foreach (Enemy enemy in _enemies)
        // {
        //     enemy.CheckDeath(this);
        // }
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
                Dictionary<string, Enemy> enemyDict = new();
                while (!enemyDict.ContainsKey(input))
                {
                    enemyDict = DisplayEnemies();
                    input = Printer.WriteRead("(Enter the corrisponding number of the enemy you want to target.)");
                    // Enemy target = null;
                    if (enemyDict.ContainsKey(input))
                    {
                        Enemy target = enemyDict[input];
                        didPerformAction = true;
                        player.MakeAttack(attack, target);
                        target.CheckDeath(this);
                    }
                    // else
                    // {
                    //     Printer.PauseInput("That input doesn't work. Please enter the number of the corrisponding creature when attacking (for example enter '1' durring the next question).");
                    // }
                    
                    Console.Clear();
                }
                
                // DisplayEnemies();
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
        RemoveEnemies();
        foreach (Enemy enemy in _enemies)
        {
            enemy.AttackPlayer(player);
            player.CheckDeath();
        }
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