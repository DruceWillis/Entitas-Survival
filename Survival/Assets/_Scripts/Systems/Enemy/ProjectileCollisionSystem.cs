using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ProjectileCollisionSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    

    public ProjectileCollisionSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ProjectileCollision);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasProjectileCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var p = e.projectileCollision.projectile;
            var co = e.projectileCollision.collisionObject;

            var pe = _contexts.game.GetEntitiesWithView(p).SingleEntity();

            if (co.layer == LayerMask.NameToLayer("Player"))
            {
                var player = _contexts.game.playerEntity;
                var currentHealth = player.health.value - 1;
                player.ReplaceHealth(currentHealth);
                
                if (currentHealth <= 0)
                    player.isDestroyed = true;
                else
                    player.animator.value.SetTrigger(Constants.TakeHit);
            }
            
            pe.isDestroyed = true;
        }
    }
}
