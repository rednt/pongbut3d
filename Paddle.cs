using Godot;
using System;

public partial class Paddle : CharacterBody3D
{
    [Export] public float Speed = 8f;

    public override void _PhysicsProcess(double delta)
    {
        Vector3 dir = Vector3.Zero;
        if (Input.IsActionPressed("ui_up")) dir.Z -= 1;
        if (Input.IsActionPressed("ui_down")) dir.Z += 1;
        if (Input.IsActionPressed("ui_left")) dir.Y += 1;
        if (Input.IsActionPressed("ui_right")) dir.Y -= 1;

        Velocity = dir.Normalized() * Speed;
        MoveAndSlide();
    }

}
