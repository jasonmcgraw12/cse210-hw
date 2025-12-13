using System.ComponentModel;

class Axe : Weapon
{
    public Axe() : base ("axe", "axes", 1, 4)
    {
        AddAttack(new Chop());
    }
}