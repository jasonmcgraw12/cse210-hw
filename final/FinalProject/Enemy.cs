class Enemy
{
    private string _name;
    private int _health;
    private int _currentHealth;
    private List<Attack> _attacks = new();
    private Dictionary<Item, double> _lootTable = new();

    public Enemy(string name, int health, int currenthealth, List<Attack> attacks, Dictionary<Item, double> lootTable)
    {
        _name = name;
        _health = health;
        _currentHealth = currenthealth;
        _attacks = attacks;
        _lootTable = lootTable;
    }
}