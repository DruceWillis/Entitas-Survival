using Entitas;
using UnityEngine;

public class InitializePlayerSystem : IInitializeSystem
{
    private Contexts _contexts;
    

    public InitializePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var e = _contexts.game.CreateEntity();
        e.isPlayer = true;
        e.AddResource(_contexts.game.gameConfig.value.player);
        e.AddDisplacement(Vector3.zero);
        e.AddSpawnPosition(Vector3.zero);
        e.isCombatEntity = true;
        e.AddHealth(3);
        
        // TESTING
        for (int i = 1; i < 2; i++)
        {
            var ee = _contexts.game.CreateEntity();
            ee.isEnemy = true;
            ee.AddResource(_contexts.game.gameConfig.value.enemy);
            ee.AddDisplacement(Vector3.zero);
            ee.AddSpawnPosition(Vector3.one * (i + 1));
            ee.isCombatEntity = true;
            ee.AddHealth(10);
        }
    }
    
}
