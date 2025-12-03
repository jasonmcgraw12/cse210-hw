class StrengthUp : PassiveSkill
{
    public StrengthUp() : base(
        "Strength up"
        , "Gain 3 to your strength stat"
    )
    {
        Action<Player> effect = (player) =>
        {
            player.SetStrength(3);
        };
        SetFunction(effect);
    }
}