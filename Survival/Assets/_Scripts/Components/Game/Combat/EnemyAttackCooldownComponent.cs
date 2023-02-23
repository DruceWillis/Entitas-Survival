using Entitas;

[Game]
public class EnemyAttackCooldownComponent : IComponent
{
    public float cooldownTime;
    public float timer;
}
