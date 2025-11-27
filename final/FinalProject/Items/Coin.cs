class Coin : Item
{
    
    public Coin(int numberOfItem) : base("coins", numberOfItem, 0, 0){}
    
    public override void Use(Player player)
    {
        Console.WriteLine("You love hearing coins jingle in your pocket");
    }
}