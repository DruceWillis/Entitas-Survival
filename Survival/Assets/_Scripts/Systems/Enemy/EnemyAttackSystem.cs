using Entitas;
using Entitas.Unity;
using UnityEngine;

public class EnemyAttackSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _enemies;
    private Transform _playerTr;

    public EnemyAttackSystem(Contexts contexts)
    {
        _contexts = contexts;
        _enemies = _contexts.game.GetGroup(GameMatcher.Enemy);
    }

    public void Execute()
    {
        if (!_playerTr)
            _playerTr = _contexts.game.playerEntity.view.value.transform;
        
        foreach (var e in _enemies.GetEntities())
        {
            if (e.enemyAttackCooldown.timer <= 0)
            {
                if (e.hasRangedEnemy)
                    RangedAttack(e);
            }
            else
            {
                e.enemyAttackCooldown.timer -= Time.deltaTime;
            }
        }
    }

    private void RangedAttack(GameEntity e)
    {
        var spawnPos = e.view.value.transform.position;
        
        var go = Object.Instantiate(e.rangedEnemy.projectile, spawnPos, Quaternion.identity);
        var projectile = _contexts.game.CreateEntity();

        projectile.AddView(go);
        go.Link(projectile);
        
        var dir = _playerTr.position - spawnPos;
        
        projectile.AddDisplacement(Vector3.zero);
        projectile.AddMovable(go.GetComponent<Rigidbody2D>());
        projectile.AddSpriteRenderer(go.GetComponent<SpriteRenderer>());
        projectile.AddProjectile(dir.normalized, e.rangedEnemy.projectileSpeed);

        e.enemyAttackCooldown.timer = e.enemyAttackCooldown.cooldownTime;
    }
}
