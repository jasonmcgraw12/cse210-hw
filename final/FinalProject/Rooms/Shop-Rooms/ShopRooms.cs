class ShopRoom : Room
{
    private List<Item> _shopItems;
    public ShopRoom(string title, string description, List<Enemy> enemies, StatCheck challenge) : base(title, description, enemies, challenge)
    {
        // _title = title;
        // _description = description;
        // _enemies = enemies;
        // _challenge = challenge;
    }

    public void SetShopItems(List<Item> items)
    {
        _shopItems = items;
    }

    public override void Display(Player player)
    {
        base.Display(player);
        OpenShop(player);
    }

    public void OpenShop(Player player)
    {
        string input = "";
        // int i = 0;
        Dictionary<string, Item> shopDict = new();
        while (input.ToLower() != "end")
        {
            int i = 0;
            Console.WriteLine($"Coins: {player.GetMoney()}");
            Console.WriteLine("Is there anything you'd like to buy? (Enter 'end' to finish shopping.)");
            foreach (Item item in _shopItems)
            {
                i++;
                int itemCost = item.GetCost() - player.GetStat("charisma") / 5;
                if (itemCost <= 0)
                {
                    itemCost = 1;
                }
                Console.WriteLine($"{i}. {item} | {itemCost} coins");
                shopDict[i.ToString()] = item;
            }
            input = Console.ReadLine();

            if (input != "")
            {
                foreach (Item item in _shopItems)
                {
                    if (item.ToString() == input || (shopDict.ContainsKey(input) && shopDict[input].ToString() == item.ToString()))
                    {
                        int itemCost = item.GetCost() - player.GetStat("charisma") / 5;
                        if (itemCost <= 0)
                        {
                            itemCost = 1;
                        }
                        if (player.GetMoney() >= itemCost)
                        {
                            player.SetMoney(-itemCost);
                            player.AddToInventory(item);
                            Printer.PauseInput($"You bought the {item} for {itemCost} coins.");
                        }
                        else
                        {
                            Printer.PauseInput($"You have {player.GetMoney()} coins, but the {item} costs {itemCost} coins.");
                        }
                        break;
                    }
                }
            }
        }


        // CHANGE make a way to sell items here too
    }
}