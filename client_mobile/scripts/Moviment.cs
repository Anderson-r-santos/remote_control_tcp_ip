using Godot;
using System;
using System.Drawing;

public partial class Moviment : MeshInstance3D
{
	float speedMoviment =10f;
	Camera3D cam;
	Vector2 meshSize;
	[Export]
	bool isSecondGround = false;
	public override void _Ready()
	{
		cam = GetNode<Camera3D>("../../../3d/Camera3D");
		meshSize = ((PlaneMesh)Mesh).Size;
	}
	public void movimentThis(int dir,Vector3 front,float delta)
	{
		if(dir == 1){
			GetParent<PathFollow3D>().ProgressRatio+= 100f * delta;
		/* 	Translate((front* speedMoviment) *delta);
			if((Position.Z - meshSize.Y/2 ) > cam.Position.Z)
			{
				Vector3 newPosition = GlobalPosition;
				newPosition.Z -= meshSize.Y * 2;
				GlobalPosition = newPosition;
		
			} */
		}else if(dir == -1)
		{
		/* 	Translate((-front* speedMoviment) *delta);
			if((Position.Z + meshSize.Y/2 ) < cam.Position.Z)
			{
				Vector3 newPosition = GlobalPosition;
				newPosition.Z += meshSize.Y/2;
				GlobalPosition = newPosition;
		
			} */
		}
		
		
		//directionInZ = 0; //para o movimento
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
