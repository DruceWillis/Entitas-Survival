using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig", order = 0)]
[Game, Unique]
public class GameConfig : ScriptableObject
{
    public GameObject enemy; 
    
    [SerializeField] private LightSpell[] lightSpells;
    [SerializeField] private StrongSpell[] strongSpells;
    
    public GameObject player;
    public float PlayerSpeed = 5.0f;
    public Dictionary<eLightSpellType, LightSpell> LightSpellsMap = new();
    public Dictionary<eStrongSpellType, StrongSpell> StrongSpellsMap = new();
    public float LMBSpellCooldown = 1f/3;
    public float RMBSpellCooldown = 3f;

    private void OnValidate()
    {
        LightSpellsMap.Clear();
        
        foreach (var spell in lightSpells)
        {
            LightSpellsMap.Add(spell.SpellType, spell);
        }
        
        StrongSpellsMap.Clear();
        
        foreach (var spell in strongSpells)
        {
            StrongSpellsMap.Add(spell.SpellType, spell);
        }
    }
}

public class BaseSpell
{
    public GameObject Prefab;
    public int Damage;
}

[Serializable]
public class LightSpell : BaseSpell
{
    public eLightSpellType SpellType;
}

[Serializable]
public class StrongSpell : BaseSpell
{
    public eStrongSpellType SpellType;
}

public enum eLightSpellType
{
    Explosion
}

public enum eStrongSpellType
{
    StrongExplosion
}