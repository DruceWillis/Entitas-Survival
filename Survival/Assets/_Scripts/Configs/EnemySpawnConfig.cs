using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnConfig", menuName = "Configs/EnemySpawnConfig", order = 0)]
public class EnemySpawnConfig : ScriptableObject
{
    [SerializeField] private List<MeleeSpawnAmountDuringTime> _meleeEnemiesSpawners = new();
    [SerializeField] private List<RangedSpawnAmountDuringTime> _rangedEnemiesSpawners = new();

    public Dictionary<eMeleeEnemyType, List<WaveSpecs>> MeleeEnemiesSpawnMap = new();
    public Dictionary<eRangedEnemyType, List<WaveSpecs>> RangedEnemiesSpawnMap = new();
    
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
        MeleeEnemiesSpawnMap.Clear();
        RangedEnemiesSpawnMap.Clear();

        foreach (var meleeEnemySpawner in _meleeEnemiesSpawners)
        {
            MeleeEnemiesSpawnMap.Add(meleeEnemySpawner.SpawnType, meleeEnemySpawner.Waves);
        }
        
        foreach (var rangedEnemySpawner in _rangedEnemiesSpawners)
        {
            RangedEnemiesSpawnMap.Add(rangedEnemySpawner.SpawnType, rangedEnemySpawner.Waves);
        }
    }
    
}

[Serializable]
public class WaveSpecs
{
    public int Duration;
    public int SpawnAmount;
}

[Serializable]
public class MeleeSpawnAmountDuringTime
{
    public eMeleeEnemyType SpawnType;
    public List<WaveSpecs> Waves;
}

[Serializable]
public class RangedSpawnAmountDuringTime
{
    public eRangedEnemyType SpawnType;
    public List<WaveSpecs> Waves;
}