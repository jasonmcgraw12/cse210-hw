class Weapon : Gear
{
    List<Attack> _attacks = new();
    public Weapon(string name, int minImpactAmount, int maxImpactAmount) : base(name, 1, minImpactAmount, maxImpactAmount){}

    public void AddAttack(Attack attack)
    {
        _attacks.Add(attack);
    }

    public List<Attack> GetAttacks()
    {
        return _attacks;
    }
}