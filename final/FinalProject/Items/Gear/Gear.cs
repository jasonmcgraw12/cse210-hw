class Gear : Item
{
    public Gear(string name, string pluralName, int numberOfItem, int minImpactAmount, int maxImpactAmount) : base (name, pluralName, numberOfItem, minImpactAmount, maxImpactAmount){}
    public override void Use(Player player)
    {
        SetNumber(-1);
        player.EquipItem(this);
        Console.WriteLine($"You equipped your {this}");
    }
}