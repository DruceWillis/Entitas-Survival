using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;

    public MoveSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.View, GameMatcher.Displacement, GameMatcher.Movable));
    }

    public void Execute()
    {
        foreach (var e in _group.GetEntities())
        {
            var displacement = e.displacement.value;
            if (e.isEnemy)
            {
                displacement = Vector2.zero;
                var pos = e.view.value.transform.position;
                var player = _contexts.game.playerEntity.view.value.transform.position;
                var direction = player - pos;
                // Debug.Log(direction.sqrMagnitude);
                if (!(direction.sqrMagnitude <= 4f))
                {
                    var dir = (player - pos).normalized;
                    displacement = dir * 3;
                }
            }
            e.movable.rigidbody2D.MovePosition(e.movable.rigidbody2D.position + (Vector2)(displacement * Time.deltaTime));
            
            if (e.hasAnimator)
            {
                bool isMoving = displacement.sqrMagnitude > 0;
                e.animator.value.SetBool(Constants.IsMoving, isMoving);
            }

            if (displacement.x > 0)
                e.spriteRenderer.value.flipX = false;
            else if (displacement.x < 0)
                e.spriteRenderer.value.flipX = true;
            
        }
        // var dir = 
        // _contexts.game.playerEntity.ReplaceMove(_contexts.input.inputManager.movementInput * Time.deltaTime * 5);
    }
}
