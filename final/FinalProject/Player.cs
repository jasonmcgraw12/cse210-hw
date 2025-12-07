using System.Net.Mail;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

class Player
{
    private string _name;
    private int _coins;
    private int _xp;
    private int _level = 1;
    private int _skillPoints;
    private int _xpGoal = 100;
    private int _health;
    private int _currentHealth;
    private int _strength;
    private int _dexterity;
    private int _intelligence;
    private int _charisma;
    private Weapon _weapon = new Dagger();
    private Armor _armor = new TatteredLeather();
    private List<Skill> _skills = new();
    private Dictionary<Item, int> _inventory = new();

    public Player(
    string name,
    int health,
    int strength, 
    int dexterity, 
    int intelligence, 
    int charisma)
    {
        _name = name;
        _health = health;
        _currentHealth = health;
        _strength = strength;
        _dexterity = dexterity;
        _intelligence = intelligence;
        _charisma = charisma;
    }

    public void SetHealth(int changeAmount)
    {
        _currentHealth += changeAmount;
        if (_currentHealth > _health)
        {
            _currentHealth = _health;
        }
    }

    public void SetTotalHealth(int changeAmount)
    {
        _health += changeAmount;
    }

    public void SetStrength(int changeAmount)
    {
        _strength += changeAmount;
    }

    public void SetDexterity(int changeAmount)
    {
        _dexterity += changeAmount;
    }
    
    public void SetIntelligence(int changeAmount)
    {
        _intelligence += changeAmount;
    }
    
    public void SetCharisma(int changeAmount)
    {
        _charisma += changeAmount;
    }

    public void SetMoney(int changeAmount)
    {
        _coins += changeAmount;
    }

    public void SetSkillPoints(int changeAmount)
    {
        _skillPoints += changeAmount;
    }

    public Weapon GetWeapon()
    {
        return _weapon;
    }

    public Armor GetArmor()
    {
        return _armor;
    }

    public Dictionary<Item, int> GetInventory()
    {
        return _inventory;
    }

    public List<Item> GetItems()
    {
        return _inventory.Keys.ToList();
    }
    public int GetStat(string statName)
    {
        if (statName == "health")
        {
            return _health;
        }
        else if (statName == "currentHealth")
        {
            return _currentHealth;
        }
        else if (statName == "strength")
        {
            return _strength;
        }
        else if (statName == "dexterity")
        {
            return _dexterity;
        }
        else if (statName == "inteligence")
        {
            return _intelligence;
        }
        else if (statName == "charisma")
        {
            return _charisma;
        }
        else
        {
            Printer.PrintError($"The stat '{statName}' does not exist. Returning 0");
            return 0;
        }
    }

    public int GetLevel()
    {
        return _level;
    }

    public int GetMoney()
    {
        return _coins;
    }

    public int GetBlock()
    {
        if (_armor == null)
        {
            return 0;
        }
        return _armor.GetEffectAmount();
    }

    public override string ToString()
    {
        return _name;
    }

    public void CheckDeath()
    {
        if (_currentHealth <= 0)
        {
            Printer.PauseInput("You died.");
            // WARNING save game here.
            Environment.Exit(0);
        }
    }
    public void AddToInventory(Item item)
    {
        if (item is Coin coin)
        {
            _coins += coin.GetNumber();
        }
        else if (item is Xp xp)
        {
            _xp += xp.GetNumber();
        }
        else if (_inventory.ContainsKey(item))
        {
            _inventory[item] += item.GetNumber();
        }
        else
        {
            bool didAddToInventory = false;
            foreach (Item inventoryItem in _inventory.Keys)
            {
                if (inventoryItem.ToString() == item.ToString())
                {
                    _inventory[inventoryItem] += item.GetNumber();
                    didAddToInventory = true;
                }
            }
            if (!didAddToInventory)
            {
                if (item.GetNumber() > 0)
                {
                    _inventory[item] = item.GetNumber();
                }
                else
                {
                    _inventory[item] = 1;
                }
            }
        }
    }

    public void DisplayInventory()
    {
        bool usedItem = false;
        int i = 1;
        Dictionary<string, Item> itemDict = new();
        Console.WriteLine($"Coins: {_coins} \nXP: {_xp}/{_xpGoal}\nWeapon: {_weapon} {_weapon.GetInfo()}\nArmor: {_armor} {_armor.GetInfo()}");
        Console.WriteLine("What would you like to use? (if you don't want to use an item press enter to continue)");
        foreach (Item item in _inventory.Keys)
        {
            Console.WriteLine($"{i}. {item} {item.GetInfo()}");
            // WARNING should make effect ranges depend on the item, this works great for food, but weapons need a different system since they can have multiple attacks
            itemDict[i.ToString()] = item;
            i++;
        }
        string input = Console.ReadLine();

        if (input != "")
        {
            foreach (Item item in _inventory.Keys)
            {
                if (item.ToString() == input || (itemDict.ContainsKey(input) && itemDict[input].ToString() == item.ToString()))
                {
                    item.Use(this);
                    usedItem = true;
                    
                    RemoveFromInventory(item);
                    break;
                }
                // else if (itemDict.ContainsKey(input))
                // {
                //     item.Use(this);

                // }
            }
            if (usedItem == false)
            {
                Console.WriteLine("I couldn't find the item you're looking for.");
            }
        }
        Printer.PauseInput("");
    }

    public void RemoveFromInventory(Item item)
    {
        _inventory[item]--;
        // item.SetNumber(-1);
        if (_inventory[item] <= 0)
        {
            _inventory.Remove(item);
        }
    }

    public Attack DisplayAttacks()
    {
        string input = "";
        Attack attackChoice = null;
        while (attackChoice == null)
        {
            
            
            Dictionary<string, Attack> attackDict = new();
            Console.WriteLine("What attack would you like to perform?");
            int i = 1;
            foreach (Attack attack in _weapon.GetAttacks(this))
            {
                attackDict[i.ToString()] = attack;
                Console.WriteLine($"{i}. {attack}");
                i++;
            }
            input = Console.ReadLine();
            Console.Clear();
            

            if (attackDict.ContainsKey(input))
            {
                attackChoice = attackDict[input];
            }
            else
            {
                foreach (Attack attack in _weapon.GetAttacks(this))
                {
                    if (input == attack.ToString())
                    {
                        attackChoice = attack;
                    }
                }
            }
            // if (attackChoice == null)
            // {
            //     Printer.PrintError("The attack was not found, returning punch");
            //     attackChoice = new Punch();
            // }
        }
        Console.WriteLine($"You ready your {attackChoice} attack.");
        return attackChoice;
    }

    public void MakeAttack(Attack attack, Enemy enemy)
    {
        string attackSynonym = attack.GetSynonym();
        int damage = attack.Hit(enemy);
        Printer.PauseInput($"You {attackSynonym} the {enemy} dealing {damage} damage.");
    }

    public void EquipItem(Item item)
    {
        if (item is Weapon weapon)
        {
            _weapon = weapon;
        }
        if (item is Armor armor)
        {
            // if (_armor != null)
            // {
            //     AddToInventory(_armor);
            // }
            _armor = armor;
        }
    }

    public void EnterRoom(Room room)
    {
        room.SetPlayer(this);
        room.Display(this);
    }

    public void LevelUp()
    {
        if (_xp >= _xpGoal)
        {
            Printer.PauseInput("You leveled up in the last room! You received 2 skill points.");
            _xp -= _xpGoal;
            _level++;
            _xpGoal = 100*_level;
            // _xp = 0;
            _skillPoints += 2;

            ChooseSkills();

            DisplayStats();
        }
    }

    private void ChooseSkills()
    {
        String input = "";
        Random rnd = new();
        List<Skill> skills = new()
        {
            new CharismaUp()
            , new CoinShower()
            , new DexterityUp()
            , new HealthUp()
            , new IntelligenceUp()
            , new StatUp()
            , new StrengthUp()
        };
        List<Skill> randomSkills = skills.OrderBy(x => rnd.Next()).Take(3).ToList();

        Dictionary<string, Skill> skillDict = new();
        while (!skillDict.ContainsKey(input))
        {
            Console.WriteLine("Which skill would you like to develop? (Enter '1', '2', or '3')");
            int i = 0;
            foreach (Skill skill in randomSkills)
            {
                i++;
                Console.Write($"{i}. ");
                skill.Display();
                skillDict[i.ToString()] = skill;
            }

            input = Console.ReadLine();
            if (skillDict.ContainsKey(input))
            {
                Skill skill = skillDict[input];
                _skills.Add(skill);
                if (skill is PassiveSkill passiveSkill)
                {
                    passiveSkill.LevelUpEffect(this);
                }
            }
        }

    }

    public void DisplaySkills()
    {
        foreach (Skill skill in _skills)
        {
            skill.Display();
        }
        Printer.PauseInput("");
    }

    public void DisplayStats()
    {
        string displayMessage = $"""
            1. health ({_currentHealth}/{_health})
            2. strength ({_strength})
            3. dexterity ({_dexterity})
            4. intelligence ({_intelligence})
            5. charisma ({_charisma})
            """;
        if (_skillPoints > 0)
        {
            string input = "";
            do
            {
                displayMessage = $"""
                You have {_skillPoints} remaining skill points. What stat would you like to increase?
                1. health ({_health})
                2. strength ({_strength})
                3. dexterity ({_dexterity})
                4. intelligence ({_intelligence})
                5. charisma ({_charisma})
                """;
                input = Printer.WriteRead(displayMessage);
                if (input == "1" || input.ToLower() == "health")
                {
                    _health += 5;
                    _skillPoints--;
                }
                else if (input == "2" || input.ToLower() == "strength")
                {
                    _strength += 1;
                    _skillPoints--;
                }
                else if (input == "3" || input.ToLower() == "dexterity")
                {
                    _dexterity += 1;
                    _skillPoints--;
                }
                else if (input == "4" || input.ToLower() == "intelligence")
                {
                    _intelligence += 1;
                    _skillPoints--;
                }
                else if (input == "5" || input.ToLower() == "charisma")
                {
                    _charisma += 1;
                    _skillPoints--;
                }
            }
            while (_skillPoints > 0 && (input == "1" || input == "2" || input == "3" || input == "4" || input == "5"));
            
        }
        else
        {
            Printer.PauseInput(displayMessage);
        }
    }
}