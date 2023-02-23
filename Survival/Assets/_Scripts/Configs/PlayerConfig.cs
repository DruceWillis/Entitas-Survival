using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 0)]
public class PlayerConfig : ScriptableObject
{
     public GameObject player;
     public float PlayerSpeed = 5.0f;
     public int Health = 3;
}
