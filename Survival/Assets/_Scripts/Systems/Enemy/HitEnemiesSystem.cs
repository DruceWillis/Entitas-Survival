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
                var currentHealth = enemyEntity.health.value - damage;
                enemyEntity.ReplaceHealth(currentHealth);
                var damageText = Object.Instantiate(_contexts.game.gameConfig.value.DamageTextPrefab, enemyEntity.view.value.transform.position, Quaternion.identity);
                damageText.Initialize(damage);
                if (currentHealth <= 0)
                    enemyEntity.isDestroyed = true;
                else
                    enemyEntity.animator.value.SetTrigger(Constants.TakeHit);
            }
        }
    }
}
