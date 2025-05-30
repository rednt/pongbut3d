using Godot;
using System;

public partial class PaddleAi : CharacterBody3D
{
    [Export] public float Speed = 8f;
    [Export] public NodePath BallPath;

    private Ball _ball;

    public override void _Ready()
    {
        _ball = GetNode<Ball>(BallPath);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_ball == null) return;

        Vector3 ballPos = _ball.GlobalTransform.Origin;
        Vector3 paddlePos = GlobalTransform.Origin;

        
        float direction = ballPos.Z - paddlePos.Z;

        Vector3 velocity = Vector3.Zero;

        if (Mathf.Abs(direction) > 0.1f) 
        {
            velocity.Z = Mathf.Sign(direction) * Speed;
        }

        // Set the new velocity
        Velocity = velocity;

        MoveAndSlide();
    }
}
