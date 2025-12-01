class CagedShop : ShopRoom
{
    public CagedShop(int level) : base(
        "Vault Room"
        , "There's a caged man locked behind bars. \"You there! If you can get me outa here I'll show you my wares.\""
        , new List<Enemy>()
        , new StatCheck(
            "Would you like to pick the lock?"
            , "You take an hour trying to figure out the lock, \"Tell you what, just leave me here and find someone else to pick the lock.\""
            , $"You pick the lock. The shop keeper gives you {5*level} coins and shows you his wares."
            , "dexterity"
            , 2+level
            , new List<Item>(){new Coin(5*level)}
        )
    )
    {
        SetShopItems(new List<Item>()
        {
            new Food("steak", 1, 10, 20)
            , new Axe()
        });
    }
}