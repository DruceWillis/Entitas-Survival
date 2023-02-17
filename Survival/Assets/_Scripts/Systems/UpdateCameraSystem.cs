using Entitas;
using UnityEngine;

public class UpdateCameraSystem : IExecuteSystem
{
    private Contexts _contexts;
    private readonly Camera _camera;

    public UpdateCameraSystem(Contexts contexts, Camera camera)
    {
        _contexts = contexts;
        _camera = camera;
    }

    public void Execute()
    {
        if (!_contexts.game.playerEntity.hasView) return;
        if (_contexts.game.playerEntity.view.value)
            _camera.transform.position = _contexts.game.playerEntity.view.value.transform.position 
                                         + new Vector3(0, 0, -10);
    }
}
