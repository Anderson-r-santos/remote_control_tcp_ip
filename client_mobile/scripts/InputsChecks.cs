using Godot;
using System;

public partial class InputsChecks : Node
{
	char left = '5';
	char right = '8';
	char accelerate = '9';
	char brake = '2'; //nao pode ser break
	Client_mobile client;
	Ground scGround ;
	public override void _Ready()
	{
		client = GetNode<Client_mobile>("../client");
		TouchScreenButton buttonBreak  = GetNode<TouchScreenButton>("../break_button");
		TouchScreenButton buttonAcce  = GetNode<TouchScreenButton>("../accelerate_button");
		Vector2I sizeScreen =  GetViewport().GetWindow().Size;
		buttonBreak.GlobalPosition = sizeScreen - new Vector2I(200,200) ;
		buttonAcce.GlobalPosition = sizeScreen - new Vector2I(400,250) ;
		scGround = GetNode<Ground>("../3d/Camera3D/ground_control");
	}




	// Called every frame. 'delta' is the elapsed time since the previous frame.
	private void checkButton(string actionName,ref char button)
	{

	 	if(Input.IsActionPressed(actionName))
		{
			button = '1';
			scGround.checkMoviment(actionName);
		}else{
			button = '0';
			
		} 
	}
		private void checkButtonInverse(string actionName,ref char button)
	{

	 	if(Input.IsActionPressed(actionName))
		{
			button = '0';
			scGround.checkMoviment(actionName);
		}else{
			button = '1';
			
		} 
	}


	private void serializeData()
	{
		byte[] data = new byte[4];

		data[0] = (byte)(left);
		data[1] = (byte)(right);
		data[2] = (byte)(brake);
		data[3] = (byte)(accelerate);

		string s = "";
		for (int i = 0; i < data.Length; i++)
		{
			s += (char)data[i];
		}
			GD.Print("enviando os dados : " + s+ " para o server");
		client.sendDataToServer(data);
	}
	public override void _Process(double delta)
	{
		checkButton("left",ref left);
		checkButton("right",ref right);
		checkButton("accelerate",ref accelerate);
		checkButton("break",ref brake);
	}
}
