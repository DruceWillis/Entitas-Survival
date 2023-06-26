using Entitas;
using UnityEngine;

public class UpdateCameraSystem : IExecuteSystem
{
    private Contexts _contexts;
    private readonly Camera _camera;

    private Vector3 _cameraOffset;
    
    public UpdateCameraSystem(Contexts contexts, Camera camera)
    {
        _contexts = contexts;
        if (_contexts == null) Debug.Log("YO");
        _camera = camera;
        _cameraOffset = new Vector3(0, 0, _camera.transform.position.z);
    }

    public void Execute()
    {
        if (!_contexts.game.playerEntity.hasView || !_contexts.game.playerEntity.view.value) return;

        var playerPos = _contexts.game.playerEntity.view.value.transform.position;
        _camera.transform.position = playerPos + _cameraOffset;
    }
}
