using Godot;
using System;
using System.Net.Sockets;


public partial class Client_mobile : Node
{
	
	StreamPeerTcp client;
	Godot.Collections.Array data;
	Label statusConnection;
	//TcpClient tcp;
	public override void _Ready()
	{
		statusConnection = GetNode<Label>("../status_connection");
		client = new StreamPeerTcp();
		GD.Print(client.ConnectToHost("10.0.0.145",9001));
	}

	private void tryConnetToServer()
	{

	}
	private void readDataFromServer()
	{
		
		while(client.GetAvailableBytes() > 0)
		{
			data = client.GetData(1024);
			string textoRecebido = "";
			for (int i = 0; i < data.Count; i++)
			{
				textoRecebido+=data[i];
			}
			GD.Print("mensagem recebida do servidor " + textoRecebido);
		}
		
	}
	public void sendDataToServer(byte[] data)
	{

		client.PutData(data);
	}

	private void checkConnectionStatus()
	{
		string status = "";
		client.Poll();
		if(client.GetStatus() == StreamPeerTcp.Status.Connected)
		{
			status = "conectado";
		}else if(client.GetStatus() == StreamPeerTcp.Status.Connecting)
		{
			status = "conectando...";
		}else if(client.GetStatus() == StreamPeerTcp.Status.None)
		{
			status = "desconectado";
		}else
		{
			status = "erro na conexao";
		}
		statusConnection.Text = "status da conexao : " + status;
	}
	public override void _Process(double delta)
	{
		// if(client.GetStatus() == StreamPeerTcp.Status.Connected)
		// {
		// 	readDataFromServer();
		// }
	}
}
