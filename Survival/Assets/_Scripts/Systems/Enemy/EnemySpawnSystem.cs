using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class EnemySpawnSystem : IInitializeSystem
{
    private Contexts _contexts;
    private MonoBehaviour _coroutineHelper;
    private EnemyConfig _enemyConfig;
    private EnemySpawnConfig _enemySpawnConfig;

    public EnemySpawnSystem(Contexts contexts, MonoBehaviour coroutineHelper)
    {
        _contexts = contexts;
        _enemyConfig = _contexts.game.gameConfig.value.EnemyConfig;
        _enemySpawnConfig = _contexts.game.gameConfig.value.EnemySpawnConfig;
        _coroutineHelper = coroutineHelper;
    }
    
    public void Initialize()
    {
        foreach (var kvp in _enemySpawnConfig.RangedEnemiesSpawnMap)
        {
            _coroutineHelper.StartCoroutine(SpawnRangedEnemyWave(kvp.Key, kvp.Value, 0));
        }
    }
    
    private IEnumerator SpawnRangedEnemyWave(eRangedEnemyType enemyType, List<WaveSpecs> waves, int index)
    {
        var currentWave = waves[index];
        var waitTime = (float) currentWave.Duration / currentWave.SpawnAmount;

        var blueprint = _enemyConfig.RangedEnemiesMap[enemyType];
        
        for (int i = 0; i < currentWave.SpawnAmount; i++)
        {
            SpawnRangedEnemy(blueprint);
            yield return new WaitForSeconds(waitTime);
        }

        if (waves.Count == index - 1) yield break;
        
        _coroutineHelper.StartCoroutine(SpawnRangedEnemyWave(enemyType, waves, index + 1));
    }

    private void SpawnMeleeEnemy(MeleeEnemy blueprint)
    {
        var e = SpawnEnemy(blueprint);
    }
    
    private void SpawnRangedEnemy(RangedEnemy blueprint)
    {
        var e = SpawnEnemy(blueprint);
        e.AddRangedEnemy(blueprint.Range, blueprint.Projectile, blueprint.ProjectileSpeed);
    }
    
    private GameEntity SpawnEnemy(EnemyBase blueprint)
    {
        var e = _contexts.game.CreateEntity();
        
        e.AddEnemy(blueprint.GrantedEXPGemType);
        e.AddResource(blueprint.Prefab);
        e.AddDisplacement(Vector3.zero);
        e.AddSpawnPosition(new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0f));
        e.AddCombatEntity(blueprint.Health, blueprint.Speed);
        e.AddHealth(blueprint.Health);
        e.AddEnemyAttackCooldown(blueprint.AttackCooldown, 0);
        return e;
    }
}
