using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellConfig", menuName = "Configs/SpellConfig", order = 0)]
public class SpellConfig : ScriptableObject
{
    
    [SerializeField] private List<LightSpell> _lightSpells = new();
    [SerializeField] private List<StrongSpell> _strongSpells = new();

    public Dictionary<eLightSpellType, LightSpell> LightSpellsMap = new();
    public Dictionary<eStrongSpellType, StrongSpell> StrongSpellsMap = new();
    public BaseSpell IceSpear;

    public float LMBSpellCooldown = 1f/3;
    public float RMBSpellCooldown = 3f;
    public float IceSpearCooldown = 2f;
    
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
        LightSpellsMap.Clear();
        
        foreach (var spell in _lightSpells)
        {
            LightSpellsMap.Add(spell.SpellType, spell);
        }
        
        StrongSpellsMap.Clear();
        
        foreach (var spell in _strongSpells)
        {
            StrongSpellsMap.Add(spell.SpellType, spell);
        }
    }
}


[Serializable]
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
