using Godot;
using System;

public partial class Ground : Node3D
{
	// Called when the node enters the scene tree for the first time.

	float rotMoviment =.5f;
	Camera3D cam;
	int directionInZ =0;
	Vector3 rotateDir;
	public override void _Ready()
	{
		RenderingServer.SetDebugGenerateWireframes(true);
		GetViewport().DebugDraw= Viewport.DebugDrawEnum.Wireframe;
		cam = GetNode<Camera3D>("../");
	}

	public void checkMoviment(string action)
	{
		if(action == "accelerate")
		{
			directionInZ = 1;
		}else if(action ==  "break")
		{
			directionInZ =  -1;
		}

		if(action == "left")
		{
			rotateDir = Vector3.Left;
		}else if(action ==  "right")
		{
			rotateDir = Vector3.Right;
		}
	}

	private void moviment(double delta)
	{

		for (int i = 0; i < GetChildCount(); i++)
		{
		
			GetChild<Moviment>(i).movimentThis(directionInZ,cam.Basis.Z,(float)delta);
			
		}
		directionInZ = 0; //para o movimento
	}



	private void rotate(double delta)
	{
		cam.GlobalRotate(Vector3.Up,(rotateDir.X*rotMoviment )*(float)delta);
		rotateDir = Vector3.Zero; // para a rotacao
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		rotate(delta);
		moviment(delta);
		//updateInfiniteTerrain();
	}
}
