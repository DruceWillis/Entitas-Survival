﻿using UnityEngine;

public class UnityInputService : IInputService
{
    private readonly Camera _camera;
    
    public UnityInputService(Camera camera)
    {
        _camera = camera;
    }
    
    public Vector2 MovementInput => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    public Vector2 MouseWorldPosition => _camera.ScreenToWorldPoint(Input.mousePosition);
    public bool LMBWasPressed => Input.GetMouseButtonDown(0);
    public bool LMBIsPressed => Input.GetMouseButton(0);
    public bool RMBWasPressed => Input.GetMouseButtonDown(1);
    public bool RMBWasReleased => Input.GetMouseButtonUp(1);
}
