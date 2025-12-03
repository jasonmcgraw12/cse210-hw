using Microsoft.VisualBasic;

class Attack
{
    private string _name;
    private Object _owner;
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

    public int[] GetDamageRange()
    {
        return [_minDamage,_maxDamage];
    }

    public int GetStaminaUsed()
    {
        return _staminaUsed;
    }

    public string GetSynonym()
    {
        Random rnd = new();
        int i = rnd.Next(_attackSynonyms.Count());
        return _attackSynonyms[i];
    }

    public string GetStat()
    {
        return _statUsed;
    }

    public void SetOwner(Object owner)
    {
        // WARNING might need to cast object as a player or enemy
        _owner = owner;
    }

    public int Hit(object target)
    {
        Random rnd = new();
        int damage = rnd.Next(_minDamage, _maxDamage);
        if (_owner is Enemy ownerEnemy)
        {
            damage += ownerEnemy.GetLevel();
        }
        else if (_owner is Player ownerPlayer)
        {
            damage += ownerPlayer.GetStat(_statUsed)/5;
        }
        
        switch (target)
        {
            case Player targetPlayer:
                damage -= targetPlayer.GetBlock();
                if (damage < 0)
                {
                    damage = 0;
                }
                targetPlayer.SetHealth(-damage);
                break;
            case Enemy targetEnemy:
                targetEnemy.SetHealth(-damage);
                break;
        }
        return damage;
    }

    public override string ToString()
    {
        return _name;
    }
}