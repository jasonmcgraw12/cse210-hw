using System.ComponentModel;

class Axe : Weapon
{
    public Axe() : base ("axe", 1, 4)
    {
        AddAttack(new Chop());
    }
}