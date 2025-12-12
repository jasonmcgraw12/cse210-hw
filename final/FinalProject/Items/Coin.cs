class Coin : Item
{
    public Coin(int numberOfItem) : base("coins", numberOfItem, 0, 0){}
    
    public override void Use(Player player)
    {
        Printer.PrintError("You should not be able to use coins");
    }
}