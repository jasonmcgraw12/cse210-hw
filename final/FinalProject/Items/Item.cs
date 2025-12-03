abstract class Item
{
    // public Random rnd = new();
    private string _name;
    private int _numberOfItem;
    private List<int> _effectRange = new();

    public abstract void Use(Player player);

    public Item(string name, int numberOfItem, int minImpactAmount, int maxImpactAmount)
    {
        _name = name;
        _effectRange.Add(minImpactAmount);
        _effectRange.Add(maxImpactAmount);
        _numberOfItem = numberOfItem;
    }

    public void SetNumber(int changeNumber)
    {
        _numberOfItem += changeNumber;
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

    public int GetCost()
    {
        int cost = (_effectRange[0]+_effectRange[1])/2;
        return cost;
    }

    public virtual string GetInfo()
    {
        return $"[{GetEffectRange()[0]}-{GetEffectRange()[1]}]";
    }

    public override string ToString()
    {
        return _name;
    }
}