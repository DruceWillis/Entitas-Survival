using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.AddProjectileCollision(gameObject, col.gameObject);
        // Debug.LogError($"{col.gameObject.name} | {col.gameObject.layer}");
    }
}
