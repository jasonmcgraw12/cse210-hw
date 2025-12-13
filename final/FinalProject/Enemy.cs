using System.Linq.Expressions;
using System.Runtime.CompilerServices;

class Enemy
{
    private string _name;
    private int _level;
    private int _health;
    private int _currentHealth;
    private int _stamina;
    private int _currentStamina;
    private List<Attack> _attacks = new();
    private Dictionary<Item, double> _lootTable = new();

    public Enemy(string name, int level, int health, int currenthealth, List<Attack> attacks, Dictionary<Item, double> lootTable)
    {
        _name = name;
        _level = level;
        _health = health;
        _currentHealth = currenthealth;
        _stamina = health;
        _currentStamina = currenthealth; // Warning stamina uses health when constructed, this might not be desired behavior
        _attacks = attacks;
        _lootTable = lootTable;
        _lootTable[new Xp(level*50)] = 1.0;
        foreach (Attack attack in _attacks)
        {
            attack.SetOwner(this); // WARNING this attack doesn't benefit from stat bonus
        }
    }

    public void SetHealth(int damage)
    {
        _currentHealth += damage;
        if (_currentHealth >= _health)
        {
            _currentHealth = _health;
        }
    }

    public int GetLevel()
    {
        return _level;
    }

    public void Display()
    {
        Console.WriteLine($"{_name}: {_currentHealth}");
    }

    public void AttackPlayer(Player player)
    {
        Attack attackChoice = null;
        foreach (Attack attack in _attacks)
        {
            int staminaUsed = attack.GetStaminaUsed();
            if (_currentStamina-staminaUsed >= 0)
            {
                if (attackChoice == null || staminaUsed > attackChoice.GetStaminaUsed())
                {
                    attackChoice = attack;
                }
            }
        }

        if (attackChoice == null)
        {
            Recharge();
        }
        else
        {
            string attackSynonym = attackChoice.GetSynonym();
            int damage = attackChoice.Hit(player);
            Printer.PauseInput($"The {this} {attackSynonym} you dealing {damage} damage. \nHealth: {player.GetStat("currentHealth")}/{player.GetStat("health")}");
        }
    }

    private void Recharge()
    {
        _currentStamina = _stamina;
    }

    public void CheckDeath(Room room)
    {
        if (_currentHealth <= 0)
        {
            foreach (Item item in _lootTable.Keys)
                {
                    Random rnd = new();
                    double chance = rnd.NextDouble();
                    double probability = _lootTable[item];
                    if (chance <= probability)
                    {
                        Player player = room.GetPlayer();
                        player.AddToInventory(item);
                        Printer.PauseInput($"You recieved {item.GetNumber()} {item.GetName()} for killing the {this}!");
                    }
                }
            room.SetDyingEnemy(this);
        }
    }

    public override string ToString()
    {
        return _name;
    }
}