using Godot;
using System;

public partial class Ball : RigidBody3D
{
    [Export] public float Speed = 15f;

    public override void _Ready()
    {
        Launch();
    }

    public void Launch()
    {
        // Start the ball in a random horizontal direction
        Vector3 direction = new Vector3(
            GD.Randf() > 0.5f ? 1 : -1,
            0,
            (float)GD.RandRange(-0.5f, 0.5f)
        ).Normalized();

        LinearVelocity = direction * Speed;
    }

    public override void _IntegrateForces(PhysicsDirectBodyState3D state)
    {
        if (state.LinearVelocity.Length() != Speed)
            state.LinearVelocity = state.LinearVelocity.Normalized() * Speed;
        Vector3 v = state.LinearVelocity;
        v.Y = 0; // prevent bouncing upward/downward
        state.LinearVelocity = v.Normalized() * Speed;
    }

    public void ResetPosition(Vector3 position)
    {
        GlobalTransform = new Transform3D(Basis.Identity, position);
        LinearVelocity = Vector3.Zero;
        AngularVelocity = Vector3.Zero;
        Launch();
    }


}




