class Sword : Weapon
{
    public Sword() : base ("dagger", 1, 4)
    {
        AddAttack(new Stab());
    }
}