class HealthUp : PassiveSkill
{
    public HealthUp() : base(
        "Health up"
        , "Increases your current health by 15."
    )
    {
        Action<Player> effect = (player) =>
        {
            player.SetTotalHealth(15);
        };
        SetFunction(effect);
    }
}