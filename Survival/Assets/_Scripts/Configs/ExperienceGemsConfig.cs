using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "ExperienceGemsConfig", menuName = "Configs/ExperienceGemsConfig", order = 0)]
public class ExperienceGemsConfig : ScriptableObject
{
    [SerializeField] private List<ExperienceGem> Gems;

    public ExperienceGem GetGemByType(eExperienceGemType type)
    {
        return Gems.First(g => g.GemType == type);
    }
}

[Serializable]
public class ExperienceGem
{
    public eExperienceGemType GemType;
    public GameObject Prefab;
    public int GrantedEXP;
}

public enum eExperienceGemType
{
    Minor,
    Medium
}