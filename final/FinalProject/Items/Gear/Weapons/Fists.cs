class Fists : Weapon
{
    public Fists() : base ("fists", 1, 2)
    {
        AddAttack(new Punch());
    }
}