abstract class Item
{
    // public Random rnd = new();
    private string _name;
    private List<int> _effectRange = new();

    public abstract void Use(Player player);

    public Item(string name, int minImpactAmount, int maxImpactAmount)
    {
        _name = name;
        _effectRange.Add(minImpactAmount);
        _effectRange.Add(maxImpactAmount);
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

    public override string ToString()
    {
        return _name;
    }
}