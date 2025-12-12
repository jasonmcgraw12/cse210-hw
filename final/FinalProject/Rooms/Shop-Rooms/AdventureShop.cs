class adventureShop : ShopRoom
{
    public adventureShop(int level) : base(
        "Adventure Shop"
        , "You find a scraggly man with crooked teeth. \"Come in, come in. Rest those bones, and take a look around.\""
        , new List<Enemy>()
        , null 
    )
    {
        SetShopItems(new List<Item>()
        {
            new Ration()
            , new Axe()
            , new Sword()
            , new ChainArmor()
        });
    }
}