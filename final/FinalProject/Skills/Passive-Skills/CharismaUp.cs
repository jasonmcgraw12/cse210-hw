class CharismaUp : PassiveSkill
{
    public CharismaUp() : base(
        "Charisma up"
        , "Gain 3 to your Charisma stat"
    )
    {
        Action<Player> effect = (player) =>
        {
            player.SetCharisma(3);
        };
        SetFunction(effect);
    }
}