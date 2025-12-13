abstract class Item
{
    // public Random rnd = new();
    private string _name;
    private string _pluralName;
    private int _numberOfItem;
    private List<int> _effectRange = new();


    public Item(string name, string pluralName, int numberOfItem, int minImpactAmount, int maxImpactAmount)
    {
        _name = name;
        _pluralName = pluralName;
        _effectRange.Add(minImpactAmount);
        _effectRange.Add(maxImpactAmount);
        _numberOfItem = numberOfItem;
    }

    public void SetNumber(int changeNumber, bool replace = false)
    {
        if (replace == true)
        {
            _numberOfItem = changeNumber;
        }
        else
        {
            _numberOfItem += changeNumber;
        }
    }

    public List<int> GetEffectRange()
    {
        return _effectRange;
    }

    public int GetEffectAmount()
    {
        Random rnd = new();
        return rnd.Next(_effectRange[0], _effectRange[1]);
    }

    public int GetNumber()
    {
        return _numberOfItem;
    }

    public int GetCost(bool buyingItem = false)
    {
        int cost = _effectRange[0]+_effectRange[1];
        if (this is Food food)
        {
            cost = (_effectRange[0]+_effectRange[1])/2;
        }
        else if (this is Weapon)
        {
            cost = (_effectRange[0]+_effectRange[1])*2;
        }
        else if (this is Armor)
        {
            cost = (_effectRange[0]+_effectRange[1])*3;
        }
        if (buyingItem == true)
        {
            cost *= GetNumber();
        }
        return cost;
    }

    public virtual string GetInfo(bool displayNumber = true)
    {
        if (displayNumber)
        {
            return $"[{GetNumber()}] [{GetEffectRange()[0]}-{GetEffectRange()[1]}]";
        }
        else
        {
            return $"[{GetEffectRange()[0]}-{GetEffectRange()[1]}]";
        }
        
    }

    public abstract void Use(Player player);

    public string GetName()
    {
        if (_numberOfItem > 1 && _pluralName != null)
        {
            return _pluralName;
        }
        return _name;
    }
    public override string ToString()
    {
        return _name;
    }
}