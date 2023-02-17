using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input, Unique]
public class InputManagerComponent : IComponent
{
    public Vector2 movementInput;
    public Vector2 mouseWorldPosition;
    public bool lmbWasPressed;
    public bool lmbIsPressed;
    public bool rmbWasPressed;
    public bool rmbWasReleased;
}
