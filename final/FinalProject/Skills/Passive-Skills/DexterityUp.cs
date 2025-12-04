class DexterityUp : PassiveSkill
{
    public DexterityUp() : base(
        "Dexterity up"
        , "Gain 3 to your dexterity stat"
    )
    {
        Action<Player> effect = (player) =>
        {
            player.SetDexterity(3);
        };
        SetFunction(effect);
    }
}