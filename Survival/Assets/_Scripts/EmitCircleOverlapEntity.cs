using System;
using System.Linq;
using UnityEngine;

public class EmitCircleOverlapEntity : MonoBehaviour
{
    [SerializeField] private float _radius = 0.5f;
    [SerializeField] private LayerMask _mask;

    private void Start()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _mask);
        var objects = new GameObject[colliders.Length];
        for (var i = 0; i < colliders.Length; i++)
        {
            var c = colliders[i];
            objects[i] = c.gameObject;
        }

        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.AddSpellCollision(gameObject, objects);
    }
}
