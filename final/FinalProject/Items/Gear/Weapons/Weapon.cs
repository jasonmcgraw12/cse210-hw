class Weapon : Gear
{
    List<Attack> _attacks = new();
    // private object _owner;
    public Weapon(string name, int minImpactAmount, int maxImpactAmount) : base(name, 1, minImpactAmount, maxImpactAmount)
    {
        // _owner = owner;
    }

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

    public override string GetInfo()
    {
        Attack mainAttack = _attacks[0];
        return $"[{mainAttack.GetStat()} {mainAttack.GetDamageRange()[0]}-{mainAttack.GetDamageRange()[1]}]";
    }
}