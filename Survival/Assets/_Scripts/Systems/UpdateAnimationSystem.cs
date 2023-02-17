using System.Collections.Generic;
using Entitas;

public class UpdateAnimationSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    

    public UpdateAnimationSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Animator, GameMatcher.View));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAnimator && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.animator.value.SetTrigger(Constants.CastedLightSpell);
        }
    }
}
