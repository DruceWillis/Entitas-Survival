using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig", order = 0)]
[Game, Unique]
public class GameConfig : ScriptableObject
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private SpellConfig _spellConfig;
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private EnemySpawnConfig _enemySpawnConfig;

    public PlayerConfig PlayerConfig => _playerConfig;
    public SpellConfig SpellConfig => _spellConfig;
    public EnemyConfig EnemyConfig => _enemyConfig;
    public EnemySpawnConfig EnemySpawnConfig => _enemySpawnConfig;

}
