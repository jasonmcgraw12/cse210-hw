class PassiveSkill : Skill
{
    private Action<Player> _skillEffect;
    public PassiveSkill(string title, string description) : base(title, description){}

    public void SetFunction(Action<Player> effect)
    {
        _skillEffect = effect;
    }
}