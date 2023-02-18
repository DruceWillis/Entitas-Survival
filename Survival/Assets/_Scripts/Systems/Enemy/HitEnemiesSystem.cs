using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class HitEnemiesSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    

    public HitEnemiesSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SpellCollision);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSpellCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var spellEntity = _contexts.game.GetEntitiesWithView(e.spellCollision.spell).SingleEntity();
            var damage = spellEntity.spell.damage;

            foreach (var enemy in e.spellCollision.collisions)
            {
                var enemyEntity = _contexts.game.GetEntitiesWithView(enemy).SingleEntity();
                var currentHealth = enemyEntity.health.Health - damage;
                enemyEntity.ReplaceHealth(currentHealth);
                
                enemyEntity.animator.value.SetTrigger(Constants.TakeHit);
                
                if (currentHealth <= 0)
                    enemyEntity.isDestroyed = true;
            }
        }
    }
}
