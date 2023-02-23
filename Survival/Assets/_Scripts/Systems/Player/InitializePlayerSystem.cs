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
        var config = _contexts.game.gameConfig.value.PlayerConfig;
        
        e.isPlayer = true;

        e.AddResource(config.player);
        e.AddDisplacement(Vector3.zero);
        e.AddSpawnPosition(Vector3.zero);
        e.AddCombatEntity(config.Health, config.PlayerSpeed);
        e.AddHealth(config.Health);
    }
    
}
