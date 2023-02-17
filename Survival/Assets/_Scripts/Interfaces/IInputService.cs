
using UnityEngine;

public interface IInputService
{
    Vector2 MovementInput { get; }
    bool LMBWasPressed { get; }
    bool LMBIsPressed { get; }
    bool RMBWasPressed { get; }
    bool RMBWasReleased { get; }
}
