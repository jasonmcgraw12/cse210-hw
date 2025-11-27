using Microsoft.VisualBasic;

class Player
{
    private string _name;
    private int _health;
    private int _strength;
    private int _dexterity;
    private int _intelligence;
    private int _charisma;
    private Weapon _weapon;
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
        _health += changeAmount;
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
        if (_inventory.ContainsKey(item))
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
        Index index = 1;
        Console.WriteLine("What would you like to use? (if you don't want to use an item press enter to continue)");
        foreach (Item item in _inventory.Keys)
        {
            Console.WriteLine($"{index}. {item}");
        }
        string itemString = Console.ReadLine();

        if (itemString != "")
        {
            foreach (Item item in _inventory.Keys)
            {
                if (item.ToString() == itemString)
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
            }
            if (usedItem == false)
            {
                Console.WriteLine("I couldn't find the item you're looking for.");
            }
        }
        Printer.PauseInput("");
    }

    public void EquipItem(Item item)
    {
        if (item is Weapon weapon)
        {
            _weapon = weapon;
        }
        if (item is Armor armor)
        {
            _armor = armor;
        }
    }

    public void EnterRoom(Room room)
    {
        room.SetPlayer(this);
        room.Display();
    }

    public void LevelUp()
    {
        // CONTINUE making this
    }
}