class Sword : Weapon
{
    public Sword() : base ("sword", "swords", 1, 4)
    {
        AddAttack(new Slash());
    }
}