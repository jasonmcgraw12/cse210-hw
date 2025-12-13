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
    private int _health = 40;
    private int _currentHealth = 40;
    private int _strength = 8;
    private int _dexterity = 8;
    private int _intelligence = 8;
    private int _charisma = 8;
    private Weapon _weapon = new Dagger();
    private Armor _armor = new TatteredLeather();
    private List<Skill> _skills = new();
    private Dictionary<Item, int> _inventory = new();

    public Player(){}

    public Player(string[] generalInfo, string[] statInfo, Weapon weapon, Armor armor, List<Skill> skills, Dictionary<Item, int> items)
    {
        // name, coins, xp, level, skillpoints, xpGoal
        _name = generalInfo[0];
        _coins = int.Parse(generalInfo[1]);
        _xp = int.Parse(generalInfo[2]);
        _level = int.Parse(generalInfo[3]);
        _skillPoints = int.Parse(generalInfo[4]);
        _xpGoal = 100*_level;

        // health, currentHealth, strength, dexterity, intelligence, charisma
        _health = int.Parse(statInfo[0]);
        _currentHealth = int.Parse(statInfo[1]);
        _strength = int.Parse(statInfo[2]);
        _dexterity = int.Parse(statInfo[3]);
        _intelligence = int.Parse(statInfo[4]);
        _charisma = int.Parse(statInfo[5]);

        _weapon = weapon;
        _armor = armor;
        
        _skills = skills;
        _inventory = items;
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
        _currentHealth += changeAmount; // when total health increases the amount of damage you took is consistant
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

    public List<Skill> GetSkills()
    {
        return _skills;
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
        else if (statName == "intelligence")
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

    public int GetSkillPoints()
    {
        return _skillPoints;
    }

    public int GetMoney()
    {
        return _coins;
    }

    public int GetXP()
    {
        return _xp;
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
                    inventoryItem.SetNumber(item.GetNumber());
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
        Console.WriteLine($"HP: {_currentHealth}/{_health}\nCoins: {_coins} \nXP: {_xp}/{_xpGoal}\nWeapon: {_weapon} {_weapon.GetInfo(false)}\nArmor: {_armor} {_armor.GetInfo(false)}");
        Console.WriteLine("------------------------");
        if (_inventory.Count() > 0)
        {
            
            Console.WriteLine("What would you like to use? (if you don't want to use an item press enter to continue)");
            foreach (Item item in _inventory.Keys)
            {
                Console.WriteLine($"{i}. {item.GetName()} {item.GetInfo()}");
                // WARNING should make effect ranges depend on the item, this works great for food, but weapons need a different system since they can have multiple attacks
                itemDict[i.ToString()] = item;
                i++;
            }
            string input = Console.ReadLine();
            Console.Clear();

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
                }
                if (usedItem == false)
                {
                    Console.WriteLine("I couldn't find the item you're looking for.");
                }
                Printer.PauseInput("");
            }
        }
        else
        {
            Printer.PauseInput("You don't have any items in your inventory.");
        }
        Console.Clear();
    }

    public void RemoveFromInventory(Item item)
    {
        _inventory[item]--;
        item.SetNumber(-1);
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
            if (_weapon != null)
            {
                AddToInventory(_weapon);
            }
            string newWeapon = ClassFactory.GetClassName(weapon.GetType());
            _weapon = (Weapon)ClassFactory.MakeClass(newWeapon);
            // _weapon.SetNumber(1, true);
        }
        if (item is Armor armor)
        {
            if (_armor != null)
            {
                AddToInventory(_armor);
            }
            string newArmor = ClassFactory.GetClassName(armor.GetType());
            _armor = (Armor)ClassFactory.MakeClass(newArmor);
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
            Level: {_level} {_xp}/{_xpGoal}
            1. health ({_currentHealth}/{_health})
            2. strength ({_strength})
            3. dexterity ({_dexterity})
            4. intelligence ({_intelligence})
            5. charisma ({_charisma})
            """;
        if (_skillPoints > 0)
        {
            Console.Clear();
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
                    _currentHealth += 5;
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