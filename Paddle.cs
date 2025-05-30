using Godot;
using System;

public partial class Paddle : CharacterBody3D
{
    [Export] public float Speed = 8f;

    public override void _PhysicsProcess(double delta)
    {
        Vector3 dir = Vector3.Zero;
        if (Input.IsActionPressed("ui_up")) dir.Y += 1;
        if (Input.IsActionPressed("ui_down")) dir.Y -= 1;
        if (Input.IsActionPressed("ui_left")) dir.Z += 1;
        if (Input.IsActionPressed("ui_right")) dir.Z -= 1;

        Velocity = dir.Normalized() * Speed;
        MoveAndSlide();
    }

}
