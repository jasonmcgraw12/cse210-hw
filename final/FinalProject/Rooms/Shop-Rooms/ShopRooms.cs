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
        if (_shopItems.Count() > 0)
        {
            OpenShop(player);
        }
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
                int itemCost = item.GetCost(true) - player.GetStat("charisma") / 5;
                if (itemCost <= 0)
                {
                    itemCost = 1;
                }
                Console.WriteLine($"{i}. {item} | {itemCost} coins");
                shopDict[i.ToString()] = item;
            }
            Console.WriteLine($"{i + 1}. sell items");
            input = Console.ReadLine();

            if (input == (i + 1).ToString())
            {
                Console.Clear();
                SellItems(player);
            }
            if (input != "")
            {
                foreach (Item item in _shopItems)
                {
                    if (item.ToString() == input || (shopDict.ContainsKey(input) && shopDict[input].ToString() == item.ToString()))
                    {
                        int itemCost = item.GetCost(true) - player.GetStat("charisma") / 5;
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

    private void SellItems(Player player)
    {
        string input = "";
        while (input != "end")
        {
            Dictionary<string, Item> sellDict = new();
            int i = 0;
            Console.WriteLine($"Coins: {player.GetMoney()}");
            Console.WriteLine("What item would you like to sell? (Enter 'end' to go back to shop.)");
            foreach (Item item in player.GetItems())
            {
                i++;
                int sellValue = (item.GetCost() + player.GetStat("charisma") / 5) / 2;
                if (sellValue <= 0)
                {
                    sellValue = 1;
                }
                Console.WriteLine($"{i}. {item} | {sellValue} coins");
                sellDict[i.ToString()] = item;
            }
            input = Console.ReadLine();
            if (sellDict.ContainsKey(input))
            {
                Item item = sellDict[input];
                int sellValue = (item.GetCost() + player.GetStat("charisma") / 5) / 2;
                if (sellValue <= 0)
                {
                    sellValue = 1;
                }
                else if (sellValue > (item.GetCost() - player.GetStat("charisma") / 5))
                {
                    sellValue = item.GetCost() - player.GetStat("charisma") / 5;
                }
                player.SetMoney(sellValue);
                // if (player.GetInventory().ContainsKey(item))
                // {
                    
                // }
                player.RemoveFromInventory(item);
            }
            Console.Clear();
        }
    }
}