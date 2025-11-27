// Using Copilot to make DTO for Enemy data
public class EnemyData
{
    public string enemyName { get; set; }
    public int enemyHealth { get; set; }
    public AttackData attacks { get; set; }
    public Dictionary<string, string> lootTable { get; set; }
}

public class AttackData
{
    public string attackName { get; set; }
}
