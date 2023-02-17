using Entitas;
using UnityEngine;

public class PlayerDisplacementSystem : IExecuteSystem
{
    private Contexts _contexts;
    

    public PlayerDisplacementSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        _contexts.game.playerEntity.ReplaceDisplacement(
            _contexts.input.inputManager.movementInput * _contexts.game.gameConfig.value.PlayerSpeed);
    }
}
