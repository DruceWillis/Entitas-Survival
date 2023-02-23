using Entitas;
using UnityEngine;

[Game]
public class RangedEnemyComponent : IComponent
{
    public float range;
    public GameObject projectile;
    public float projectileSpeed;
}
