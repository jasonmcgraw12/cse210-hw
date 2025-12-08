class Food : Item
{
    
    public Food(string name, int numberOfItem, int minImpactAmount, int maxImpactAmount) : base(name, numberOfItem, minImpactAmount, maxImpactAmount){}
    
    public override void Use(Player player)
    {
        SetNumber(-1);
        int amount = GetEffectAmount();
        if (player.GetStat("health") > player.GetStat("currentHealth"))
        {
            player.SetHealth(amount);
            Console.WriteLine($"You munch on the {ToString()} healing {amount}. You now have {player.GetStat("currentHealth")}");
        }
    }
}