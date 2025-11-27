class Attack
{
    private string _name;
    private string _statUsed;
    private List<string> _attackSynonyms;
    private int _staminaUsed;
    private List<int> _damageRange;

    public Attack(string name, string statUsed, List<string> attackSynonyms, int staminaUsed, List<int> damageRange)
    {
        _name = name;
        _statUsed = statUsed;
        _attackSynonyms = attackSynonyms;
        _staminaUsed = staminaUsed;
        _damageRange = damageRange;
    }
}