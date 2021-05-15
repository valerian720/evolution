using Godot;
using System;

public class NetManager1 : Node2D
{
    /* 
     * данный класс отвечает за отображение сети, за расстановку объектов на экране
     * **/
    private Node2D computer = ResourceLoader.Load<Node2D>("res://Assets/Prefabs/Computer.tscn");

    public override void _Ready()
    {
        for (int i = 0; i < 10; i++)
        {
            GD.Print("======================================");
            //Node2D newComputer = (Node2D) computer.Duplicate();
            //newComputer.Position=new Vector2(newComputer.Position.x, newComputer.Position.y);
            AddChild(computer);
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
