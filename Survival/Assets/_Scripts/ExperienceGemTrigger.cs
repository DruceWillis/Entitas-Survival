using UnityEngine;

public class ExperienceGemTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.AddExperienceGemCollision(gameObject, col.gameObject);
        // Debug.LogError($"{col.gameObject.name} | {col.gameObject.layer}");
    }
}
