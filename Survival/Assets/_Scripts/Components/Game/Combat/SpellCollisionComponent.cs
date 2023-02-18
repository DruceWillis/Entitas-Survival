using Entitas;
using UnityEngine;

[Game]
public class SpellCollisionComponent : IComponent
{
    public GameObject spell;
    public GameObject[] collisions;
}
