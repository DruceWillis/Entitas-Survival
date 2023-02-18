using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class InstantiateCombatEntitySystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    

    public InstantiateCombatEntitySystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CombatEntity);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasResource && entity.isCombatEntity && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var go = Object.Instantiate(e.resource.prefab);
            e.AddView(go);
            go.Link(e);

            if (e.hasSpawnPosition)
            {
                go.transform.position = e.spawnPosition.value;
            }
            
            e.AddMovable(e.view.value.GetComponent<Rigidbody2D>());
            e.AddAnimator(e.view.value.GetComponent<Animator>());   
            e.AddSpriteRenderer(e.view.value.GetComponent<SpriteRenderer>());
        }
    }
}
