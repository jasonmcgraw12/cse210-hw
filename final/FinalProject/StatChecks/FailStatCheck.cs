class FailStatCheck : StatCheck
{
    private Room _room;
    private Action<Room> _failEffect;

    public FailStatCheck(string beginningDescription, string failDescription, string successDescription, string challengedstat, int challengeAmount, List<Item> rewards, Room room, Action<Room> failEffect) : base(beginningDescription, failDescription, successDescription, challengedstat, challengeAmount, rewards)
    {
        _room = room;
        _failEffect = failEffect;
    }

    public override void Start(Player player)
    {
        base.Start(player);
        if (!GetSuccess())
        {
            _failEffect(_room);
        }
    }
}