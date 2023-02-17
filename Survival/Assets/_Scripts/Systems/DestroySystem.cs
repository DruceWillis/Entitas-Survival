using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class DestroySystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    

    public DestroySystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroyed;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.hasView)
            {
                var go = e.view.value;
                go.Unlink();
                Object.Destroy(go);
            }

            e.Destroy();
        }
    }
}
