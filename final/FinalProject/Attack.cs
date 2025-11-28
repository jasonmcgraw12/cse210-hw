using Microsoft.VisualBasic;

class Attack
{
    private string _name;
    private string _statUsed;
    private List<string> _attackSynonyms;
    private int _staminaUsed;
    private int _minDamage;
    private int _maxDamage;

    public Attack(string name, string statUsed, List<string> attackSynonyms, int staminaUsed, List<int> damageRange)
    {
        _name = name;
        _statUsed = statUsed;
        _attackSynonyms = attackSynonyms;
        _staminaUsed = staminaUsed;
        _minDamage = damageRange[0];
        _maxDamage = damageRange[1];
    }

    public int GetStaminaUsed()
    {
        return _staminaUsed;
    }

    public void Hit(object target)
    {
        Random rnd = new();
        int damage = -rnd.Next(_minDamage, _maxDamage);
        switch (target)
        {
            case Player player:
                player.SetHealth(damage);
                break;
            case Enemy enemy:
                enemy.SetHealth(damage);
                break;
        }
    }

    public override string ToString()
    {
        return _name;
    }
}