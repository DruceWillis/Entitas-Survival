using System;
using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private Camera _camera;
    
    private Systems _updateSystems;
    private Systems _fixedUpdateSystems;
    
    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        contexts.game.SetGameConfig(_gameConfig);
    
        _updateSystems = CreateUpdateSystems(contexts);
        _updateSystems.Initialize();
        
        _fixedUpdateSystems = CreateFixedUpdateSystems(contexts);
        _fixedUpdateSystems.Initialize();
    }

    private void FixedUpdate()
    {
        _fixedUpdateSystems.Execute();
        _fixedUpdateSystems.Cleanup();
    }

    private void Update()
    {
        _updateSystems.Execute();
        _updateSystems.Cleanup();
    }
    
    private Systems CreateUpdateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new InitializePlayerSystem(contexts))
            .Add(new InstantiateCombatEntitySystem(contexts))
            .Add(new EmitInputSystem(contexts, new UnityInputService(_camera)))
            .Add(new UpdateCameraSystem(contexts, _camera))
            .Add(new SpellCastingSystem(contexts))
            .Add(new SpellStateTrackingSystem(contexts))
            .Add(new HitEnemiesSystem(contexts))
            .Add(new DestroySystem(contexts))
            ;
    }
    
    private Systems CreateFixedUpdateSystems(Contexts contexts)
    {
        return new Feature("Game")
                .Add(new PlayerDisplacementSystem(contexts))
                .Add(new EnemyDisplacementSystem(contexts))
                .Add(new MoveSystem(contexts))
            ;
    }
}
