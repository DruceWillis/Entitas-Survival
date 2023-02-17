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
            e.movable.rigidbody2D.MovePosition(e.movable.rigidbody2D.position + (Vector2)(displacement * Time.deltaTime));
            bool isMoving = displacement.sqrMagnitude > 0; 
            e.animator.value.SetBool(Constants.IsMoving, isMoving);
        }
        // var dir = 
        // _contexts.game.playerEntity.ReplaceMove(_contexts.input.inputManager.movementInput * Time.deltaTime * 5);
    }
}
