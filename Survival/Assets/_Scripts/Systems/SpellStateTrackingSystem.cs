using Entitas;
using UnityEngine;

public class SpellStateTrackingSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _spells;

    public SpellStateTrackingSystem(Contexts contexts)
    {
        _contexts = contexts;
        _spells = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Spell, GameMatcher.Animator));
    }

    public void Execute()
    {
        foreach (var e in _spells.GetEntities())
        {
            var nt = e.animator.value.GetCurrentAnimatorStateInfo(0).normalizedTime;
            
            if (nt > 1.0f)
                e.isDestroyed = true;
        }
    }
}
