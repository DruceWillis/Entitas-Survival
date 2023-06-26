using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig", order = 0)]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private List<MeleeEnemy> _meleeEnemies = new();
    [SerializeField] private List<RangedEnemy> _rangedEnemies = new();

    public Dictionary<eMeleeEnemyType, MeleeEnemy> MeleeEnemiesMap = new();
    public Dictionary<eRangedEnemyType, RangedEnemy> RangedEnemiesMap = new();
    
    private void Awake()
    {
        PopulateDictionaries();
    }
    
    private void OnValidate()
    {
        PopulateDictionaries();
    }
    
    private void PopulateDictionaries()
    {
        MeleeEnemiesMap.Clear();
        RangedEnemiesMap.Clear();

        foreach (var meleeEnemy in _meleeEnemies)
        {
            MeleeEnemiesMap.Add(meleeEnemy.EnemyType, meleeEnemy);
        }
        
        foreach (var rangedEnemy in _rangedEnemies)
        {
            RangedEnemiesMap.Add(rangedEnemy.EnemyType, rangedEnemy);
        }
    }
}

public class EnemyBase
{
    public GameObject Prefab;
    public eExperienceGemType GrantedEXPGemType;
    
    public int Health;
    public float Speed;
    public float AttackCooldown;
}

[Serializable]
public class MeleeEnemy : EnemyBase
{
    public eMeleeEnemyType EnemyType;
}

[Serializable]
public class RangedEnemy : EnemyBase
{
    public eRangedEnemyType EnemyType;
    public float Range;
    public GameObject Projectile;
    public float ProjectileSpeed;
}

public enum eMeleeEnemyType
{
    Skeleton,
}
public enum eRangedEnemyType
{
    FlyingEye,
}
