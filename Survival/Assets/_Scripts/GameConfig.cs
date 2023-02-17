using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig", order = 0)]
[Game, Unique]
public class GameConfig : ScriptableObject
{
    public GameObject player;

    public float PlayerSpeed = 5.0f;
}
