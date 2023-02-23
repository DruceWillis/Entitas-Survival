using Entitas;
using UnityEngine;

public class ProjectileDisplacementSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _entities;

    public ProjectileDisplacementSystem(Contexts contexts)
    {
        _contexts = contexts;
        _entities = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.View, GameMatcher.Projectile));
    }

    public void Execute()
    {
        foreach (var e in _entities)
        {
            e.ReplaceDisplacement(e.projectile.direction * e.projectile.speed);
        }
    }
}
