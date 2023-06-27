using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _combatEntities;
    private IGroup<GameEntity> _projectiles;

    public MoveSystem(Contexts contexts)
    {
        _contexts = contexts;
        _combatEntities = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.View, GameMatcher.Displacement, GameMatcher.Movable));
    }

    public void Execute()
    {
        foreach (var e in _combatEntities.GetEntities())
        {
            var displacement = e.displacement.value;
            e.movable.rigidbody2D.MovePosition(e.movable.rigidbody2D.position + (Vector2)(displacement * Time.deltaTime));
            
            if (e.hasAnimator)
            {
                bool isMoving = displacement.sqrMagnitude > 0;
                e.animator.value.SetBool(Constants.IsMoving, isMoving);
            }

            if (!e.hasSpriteRenderer) continue;
            
            if (displacement.x > 0)
                e.spriteRenderer.value.flipX = false;
            else if (displacement.x < 0)
                e.spriteRenderer.value.flipX = true;
        }
    }
}
