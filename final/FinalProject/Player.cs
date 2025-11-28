using System.Net.Mail;
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
    private int _strength;
    private int _dexterity;
    private int _intelligence;
    private int _charisma;
    private Weapon _weapon = new Fists();
    private Armor _armor;
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
        _strength = strength;
        _dexterity = dexterity;
        _intelligence = intelligence;
        _charisma = charisma;
    }

    public void SetHealth(int changeAmount)
    {
        _health += changeAmount; // WARNING put armor calculations here
    }

    public int GetStat(string statName)
    {
        if (statName == "health")
        {
            return _health;
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
            _inventory[item] = item.GetNumber();
        }
    }

    public void DisplayInventory()
    {
        bool usedItem = false;
        int i = 1;
        Dictionary<string, Item> itemDict = new();
        Console.WriteLine($"Coins: {_coins} \nXP: {_xp}/{_xpGoal}");
        Console.WriteLine("What would you like to use? (if you don't want to use an item press enter to continue)");
        foreach (Item item in _inventory.Keys)
        {
            Console.WriteLine($"{i}. {item}");
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
                    _inventory[item]--;
                    if (_inventory[item] <= 0)
                    {
                        _inventory.Remove(item);
                    }
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

    public Attack DisplayAttacks()
    {
        string input;
        Attack attackChoice = null;
        Dictionary<string, Attack> attackDict = new();
        Console.WriteLine("What attack would you like to perform?");
        int i = 1;
        foreach (Attack attack in _weapon.GetAttacks())
        {
            attackDict[i.ToString()] = attack;
            Console.WriteLine($"{i}. {attack}");
            i++;
        }
        input = Console.ReadLine();

        if (attackDict.ContainsKey(input))
        {
            attackChoice = attackDict[input];
        }
        else
        {
            foreach (Attack attack in _weapon.GetAttacks())
            {
                if (input == attack.ToString())
                {
                    attackChoice = attack;
                }
            }
        }
        if (attackChoice == null)
        {
            Printer.PrintError("The attack was not found, returning punch");
            attackChoice = new Punch();
        }
        return attackChoice;
    }

    public void MakeAttack(Attack attack, Enemy enemy)
    {
        attack.Hit(enemy);
    }

    public void EquipItem(Item item)
    {
        if (item is Weapon weapon)
        {
            if (_weapon.ToString() != "fists")
            {
                AddToInventory(_weapon);
            }
            _weapon = weapon;
        }
        if (item is Armor armor)
        {
            // WARNING when armor is included in the game make sure you get the previous armor your player is wearing.
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
        _level++;
        _xpGoal = 100*_level;
        _xp = 0;
        _skillPoints += 2;
        DisplayStats();
    }

    public void DisplayStats()
    {
        string displayMessage = $"""
            1. health ({_health})
            2. strength ({_strength})
            3. dexterity ({_dexterity})
            4. intelligence ({_intelligence})
            5. charisma ({_charisma})
            """;
        if (_skillPoints > 0)
        {
            displayMessage = $"""
            What stat would you like to increase?
            1. health ({_health})
            2. strength ({_strength})
            3. dexterity ({_dexterity})
            4. intelligence ({_intelligence})
            5. charisma ({_charisma})
            """;
            string input = Printer.WriteRead(displayMessage);
            if (input == "1" || input.ToLower() == "health")
            {
                _health += 10;
            }
            else if (input == "2" || input.ToLower() == "strength")
            {
                _strength += 1;
            }
            else if (input == "3" || input.ToLower() == "dexterity")
            {
                _dexterity += 1;
            }
            else if (input == "4" || input.ToLower() == "intelligence")
            {
                _intelligence += 1;
            }
            else if (input == "5" || input.ToLower() == "charisma")
            {
                _charisma += 1;
            }
        }
        else
        {
            Printer.PauseInput(displayMessage);
        }
        
    }
}