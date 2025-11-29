class Food : Item
{
    
    public Food(string name, int numberOfItem, int minImpactAmount, int maxImpactAmount) : base(name, numberOfItem, minImpactAmount, maxImpactAmount){}
    
    public override void Use(Player player)
    {
        int amount = GetEffectAmount();
        if (player.GetStat("health") > player.GetStat("currentHealth"))
        {
            player.SetHealth(amount);
            Console.WriteLine($"You munch on the {ToString()} healing {amount}");
        }

        
    }
}