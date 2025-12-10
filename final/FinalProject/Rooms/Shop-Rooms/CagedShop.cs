class CagedShop : ShopRoom
{
    public CagedShop(int level) : base(
        "Vault Room"
        , "There's a caged man locked behind bars. \"You there! If you can get me outa here I'll show you my wares.\""
        , new List<Enemy>() 
        , null 
    )
    {
        NoSuccessStatCheck check = new(
            "Would you like to pick the lock?"
            , "You take an hour trying to figure out the lock, \"Just leave me and I'll wait for someone else to get me out of here.\""
            , $"You pick the lock. The shop keeper gives you {5*level} coins and shows you his wares."
            , "dexterity"
            , 2+level
            , new List<Item>(){new Coin(5*level)}
            , this
            , (Room room) =>
            {
                if (room is ShopRoom shopRoom)
                {
                    shopRoom.SetShopItems(new List<Item>());
                }
                else
                {
                    Printer.PrintError("This room should be a shop room");
                }
            }
        );
        SetStatCheck(check);
        SetShopItems(new List<Item>()
        {
            new Food("steak", 1, 10, 20)
            , new Axe()
        });
    }
}