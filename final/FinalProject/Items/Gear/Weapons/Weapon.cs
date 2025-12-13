class Weapon : Gear
{
    private List<Attack> _attacks = new();
    public Weapon(string name, string pluralName, int minImpactAmount, int maxImpactAmount) : base(name, pluralName, 1, minImpactAmount, maxImpactAmount)
    {}

    public void AddAttack(Attack attack)
    {
        _attacks.Add(attack);
    }

    public List<Attack> GetAttacks(Object owner)
    {
        foreach (Attack attack in _attacks)
        {
            attack.SetOwner(owner);
        }
        return _attacks;
    }

    public override string GetInfo(bool displayNumber = true)
    {
        Attack mainAttack = _attacks[0];
        if (displayNumber)
        {
            return $"[{GetNumber()}] [{mainAttack.GetStat()} {mainAttack.GetDamageRange()[0]}-{mainAttack.GetDamageRange()[1]}]";
        }
        else
        {
            return $"[{mainAttack.GetStat()} {mainAttack.GetDamageRange()[0]}-{mainAttack.GetDamageRange()[1]}]";
        }
    }
}