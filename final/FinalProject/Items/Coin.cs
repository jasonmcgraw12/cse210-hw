class Coin : Item
{
    
    public Coin() : base("coins", 0, 0){}
    
    public override void Use(Player player)
    {
        Console.WriteLine("You love hearing coins jingle in your pocket");
    }
}