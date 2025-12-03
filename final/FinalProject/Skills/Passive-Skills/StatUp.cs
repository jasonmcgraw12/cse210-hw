class StatUp : PassiveSkill
{
    public StatUp() : base(
        "Stat up"
        , "Gain 2 extra skill points to increase a stat."
    )
    {
        Action<Player> effect = (player) =>
        {
            player.SetSkillPoints(2);
        };
        SetFunction(effect);
    }
}