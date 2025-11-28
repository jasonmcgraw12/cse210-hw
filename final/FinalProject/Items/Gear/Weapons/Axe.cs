using System.ComponentModel;

class Axe : Weapon
{
    public Axe() : base ("dagger", 1, 4)
    {
        AddAttack(new Chop());
    }
}