class Gear : Item
{
    public Gear(string name, int minImpactAmount, int maxImpactAmount) : base (name, minImpactAmount, maxImpactAmount){}
    public override void Use(Player player)
    {
        player.EquipItem(this);
        // Printer.PauseInput($"You equipped your {this}");
    }
}