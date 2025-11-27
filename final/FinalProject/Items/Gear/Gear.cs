class Gear : Item
{
    public Gear(string name, int minImpactAmount, int maxImpactAmount) : base (name, minImpactAmount, maxImpactAmount){}
    public override void Use(Player player)
    {
        player.EquipItem(this);
        Console.WriteLine($"You equipped your {this}");
    }
}