class Goblin : Enemy
{
    // string name, int health, int currenthealth, List<Attack> attacks, Dictionary<Item, double> lootTable
    Goblin() : base("goblin", 10, 10, List<Attack>["stab"], Dictionary<Item, Double> {"daggar": 0.1, "coin": 1.0}){}
}