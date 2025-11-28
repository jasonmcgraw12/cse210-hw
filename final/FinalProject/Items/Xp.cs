class Xp : Item
{
    
    public Xp(int numberOfItem) : base("xp", numberOfItem, 0, 0){}
    
    public override void Use(Player player)
    {
        Printer.PrintError("You should not be able to use XP");
    }
}