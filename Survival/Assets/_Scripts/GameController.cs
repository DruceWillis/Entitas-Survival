using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private Camera _camera;
    
    private Systems _systems;
    
    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        contexts.game.SetGameConfig(_gameConfig);
    
        _systems = CreateSystems(contexts);
        _systems.Initialize();
    }
    
    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
    
    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new InitializePlayerSystem(contexts))
            .Add(new InstantiateViewSystem(contexts))
            .Add(new EmitInputSystem(contexts, new UnityInputService()))
            .Add(new PlayerDisplacementSystem(contexts))
            .Add(new MoveSystem(contexts))
            .Add(new UpdateCameraSystem(contexts, _camera))
            ;
    }
}
