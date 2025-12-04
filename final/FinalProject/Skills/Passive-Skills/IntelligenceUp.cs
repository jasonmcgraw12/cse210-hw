class IntelligenceUp : PassiveSkill
{
    public IntelligenceUp() : base(
        "Intelligence up"
        , "Gain 3 to your intelligence stat"
    )
    {
        Action<Player> effect = (player) =>
        {
            player.SetIntelligence(3);
        };
        SetFunction(effect);
    }
}