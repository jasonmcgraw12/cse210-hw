using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to a text dungeon adventure!");
        Item apple = new Food("apple",1,2);
        Player player = new("name",25,10,10,10,10,10);
        player.AddToInventory(apple);
        player.DisplayInventory();
    }
}