using System.Linq.Expressions;
using System.Runtime.CompilerServices;

class Enemy
{
    private string _name;
    private int _health;
    private int _currentHealth;
    private int _stamina;
    private int _currentStamina;
    private List<Attack> _attacks = new();
    private Dictionary<Item, double> _lootTable = new();

    public Enemy(string name, int health, int currenthealth, List<Attack> attacks, Dictionary<Item, double> lootTable)
    {
        _name = name;
        _health = health;
        _currentHealth = currenthealth;
        _stamina = health;
        _currentStamina = currenthealth; // Warning stamina uses health when constructed, this might not be desired behavior
        _attacks = attacks;
        _lootTable = lootTable;
    }

    public void Display()
    {
        Console.Write($"Goblin: {_currentHealth}");
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
            attackChoice.Hit(player);
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
                        Printer.PrintError($"Spawning items on enemy death is not fully set up yet.");
                    }
                }
            room.RemoveEnemy(this);
        }
    }
}