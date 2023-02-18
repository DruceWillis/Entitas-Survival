using Entitas;
using UnityEngine;

public class EnemyDisplacementSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _entities;

    public EnemyDisplacementSystem(Contexts contexts)
    {
        _contexts = contexts;
        _entities = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.View));
    }

    public void Execute()
    {
        foreach (var e in _entities)
        {
            var displacement = Vector2.zero;
            var pos = e.view.value.transform.position;
            var player = _contexts.game.playerEntity.view.value.transform.position;
            var direction = player - pos;
            
            if (!(direction.sqrMagnitude <= 4.5f))
            {
                var dir = (player - pos).normalized;
                displacement = dir * 3;
            }

            e.ReplaceDisplacement(displacement);
        }

    }
}
