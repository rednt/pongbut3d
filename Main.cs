using Godot;
using System;

public partial class Main : Node3D
{
    [Export] public NodePath BallPath;
    [Export] public NodePath PlayerPaddlePath;
    [Export] public NodePath AiPaddlePath;

    private Ball _ball;
    private Node3D _playerPaddle;
    private Node3D _aiPaddle;

    public override void _Ready()
    {
        _ball = GetNode<Ball>(BallPath);
        _playerPaddle = GetNode<Node3D>(PlayerPaddlePath);
        _aiPaddle = GetNode<Node3D>(AiPaddlePath);

        StartRound();
    }

    private void StartRound()
    {
        GD.Print("Starting round...");
        _ball._Ready(); 
    }

    
    public void OnGoalScored(string scorer)
    {
        GD.Print($"{scorer} scored!");
        StartRound();
    }
}

