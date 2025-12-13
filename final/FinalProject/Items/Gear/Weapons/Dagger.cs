class Dagger : Weapon
{
    public Dagger() : base ("dagger", "daggers", 1, 4)
    {
        AddAttack(new Stab());
    }
}