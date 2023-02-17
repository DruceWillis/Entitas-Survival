
using UnityEngine;

public interface IInputService
{
    Vector2 MovementInput { get; }
    Vector2 MouseWorldPosition { get; }
    bool LMBWasPressed { get; }
    bool LMBIsPressed { get; }
    bool RMBWasPressed { get; }
    bool RMBWasReleased { get; }
}
