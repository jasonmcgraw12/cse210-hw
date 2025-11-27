class Gear : Item
{
    public Gear(string name, int numberOfItem, int minImpactAmount, int maxImpactAmount) : base (name, numberOfItem, minImpactAmount, maxImpactAmount){}
    public override void Use(Player player)
    {
        player.EquipItem(this);
        Console.WriteLine($"You equipped your {this}");
    }
}