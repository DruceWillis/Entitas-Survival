using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ExperienceGemCollisionSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    

    public ExperienceGemCollisionSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ExperienceGemCollision);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasExperienceGemCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var g = e.experienceGemCollision.gem;
            var co = e.experienceGemCollision.collisionObject;

            var ge = _contexts.game.GetEntitiesWithView(g).SingleEntity();

            if (co.layer == LayerMask.NameToLayer("GemMagnet"))
            {
                var player = _contexts.game.playerEntity;
                var playerLevelProgression = player.levelProgression;
                
                int currentLevel = playerLevelProgression.level;
                int currentExp = playerLevelProgression.currentEXP + ge.experienceGem.grantedEXP;
                int nextLevelRequiredExp = playerLevelProgression.nextLevelRequiredEXP;
                
                if (currentExp >= playerLevelProgression.nextLevelRequiredEXP)
                {
                    currentLevel++;
                    currentExp %= nextLevelRequiredExp;
                    nextLevelRequiredExp = (int)(nextLevelRequiredExp * 1.5f);
                }
                
                player.ReplaceLevelProgression(currentLevel, currentExp, nextLevelRequiredExp);
                
                Debug.Log($"Player level: {currentLevel}, current exp: {currentExp}, next level: {nextLevelRequiredExp}");
            }
            
            ge.isDestroyed = true;
        }
    }
}
