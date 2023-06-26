using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class ExperienceGemSpawnSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public ExperienceGemSpawnSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Destroyed, GameMatcher.Enemy));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroyed && entity.hasEnemy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var gemBlueprint = _contexts.game.gameConfig.value.GemsConfig.GetGemByType(e.enemy.gemType);
            var gemGO = Object.Instantiate(gemBlueprint.Prefab, e.view.value.transform.position, Quaternion.identity);
            var gem = _contexts.game.CreateEntity();
            
            gem.AddView(gemGO);
            gemGO.Link(gem);
            
            gem.AddExperienceGem(gemBlueprint.GrantedEXP);
        }
    }
}
