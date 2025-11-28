class Dagger : Weapon
{
    public Dagger() : base ("dagger", 1, 4)
    {
        AddAttack(new Stab());
    }
}