class Stab : Attack
{//(string name, string statUsed, List<string> attackSynonyms, int staminaUsed, List<int> damageRange)
    public Stab() : base(
        "stab"
        , "dexterity"
        , new List<string>(){"stab", "jab", "pierce"}
        , 3
        , new List<int>(){1, 4}){}
}