class Food : Item
{
    
    public Food(string name, int numberOfItem, int minImpactAmount, int maxImpactAmount) : base(name, numberOfItem, minImpactAmount, maxImpactAmount){}
    
    public override void Use(Player player)
    {

        int amount = GetEffectAmount();
        if (player.GetStat("currentHealth") < player.GetStat("health"))
        {
            SetNumber(-1);
            player.SetHealth(amount);
            Console.WriteLine($"You munch on the {ToString()} healing {amount}. You now have {player.GetStat("currentHealth")}");
        }
        else
        {
            Console.WriteLine("You are too full.");
        }
    }
}