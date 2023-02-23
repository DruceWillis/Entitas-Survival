using Entitas;
using UnityEngine;

public class EmitInputSystem : IExecuteSystem
{
    private InputContext _input;
    private IInputService _inputService;

    public EmitInputSystem(Contexts contexts, IInputService inputService)
    {
        _input = contexts.input;
        _inputService = inputService;
        _input.SetInputManager(Vector2.zero, Vector2.zero, false, false, false);
    }
    
    public void Execute()
    {
        var inputManager = _input.inputManager;
        
        inputManager.movementInput = _inputService.MovementInput;
        inputManager.mouseWorldPosition = _inputService.MouseWorldPosition;
        
        inputManager.lmbWasPressed = _inputService.LMBWasPressed;
        inputManager.lmbIsPressed = _inputService.LMBIsPressed;
        
        inputManager.rmbWasPressed = _inputService.RMBWasPressed;
    }

}
