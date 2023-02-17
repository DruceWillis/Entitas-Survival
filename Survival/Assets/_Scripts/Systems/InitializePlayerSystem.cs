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
        e.isMovable = true;
        e.AddResource(_contexts.game.gameConfig.value.player);
        e.AddDisplacement(Vector3.zero);
        e.AddSpawnPosition(Vector3.zero);
    }
    
}
