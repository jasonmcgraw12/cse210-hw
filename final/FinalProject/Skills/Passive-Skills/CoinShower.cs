class CoinShower : PassiveSkill
{
    public CoinShower() : base(
        "Coin shower"
        , "Gain gold equal to 5 times your current level"
    )
    {
        Action<Player> effect = (player) =>
        {
            player.SetMoney(5*player.GetLevel());
        };
        SetFunction(effect);
    }
}