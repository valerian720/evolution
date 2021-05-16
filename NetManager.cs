using Godot;
using System;

public class NetManager : Node2D
{
    //public NetManager(int margin, float koefX, float koefY, Color lineColor, int lineWidth){}
    

    private PackedScene computer = (PackedScene)ResourceLoader.Load("res://Assets/Prefabs/Computer.tscn");

    private Node2D PCGroup = new Node2D();
    private Node2D ConnectionGroup = new Node2D();


    int margin = 50;

    float koefX = 1.3f;
    float koefY = 1.3f;

    Color lineColor = new Color(255, 0, 0);
    int lineWidth = 1;

    public override void _Ready()
    {
        AddChild(ConnectionGroup);
        AddChild(PCGroup);

        //DrawCall();
    }

    void DrawAllComputers(Vector2[] locatons)
        {
        foreach (var location in locatons)
        {
            Node2D newComputer = (Node2D)computer.Instance();
            newComputer.Position = PrepareLocation(location);
            PCGroup.AddChild(newComputer);
        }

        //for (int i = 0; i < collumnsCount; i++)
        //    {
        //        for (int j = 0; j < rowsCount; j++)
        //        {
        //            Node2D newComputer = (Node2D)computer.Instance();
        //            newComputer.Position = new Vector2(margin + koefX * i, margin + koefY * j);
        //            PCGroup.AddChild(newComputer); 
        //        }

        //    }
    }

    internal void ClearScreen()
    {
        PCGroup.QueueFree();
        ConnectionGroup.QueueFree();

        ConnectionGroup = new Node2D();
        PCGroup = new Node2D();

        AddChild(ConnectionGroup);
        AddChild(PCGroup);
    }

    Vector2 PrepareLocation(Vector2 location) => new Vector2(location.x * koefX + margin, location.y * koefY + margin);

    void DrawConnection(Vector2[] locatons, double treshhold, double[,] netGraphWeights)
    {
        for (int i = 0; i < locatons.Length; i++)
        {
            for (int j = 0; j < locatons.Length; j++)
            {
                if (locatons[i] != locatons[j] && netGraphWeights[i,j] < treshhold)
                {
                    AddNewLine(PrepareLocation(locatons[i]), PrepareLocation(locatons[j]), 1+ (int)Math.Abs( netGraphWeights[i, j]/200));
                }
            }
        }

    }

    void AddNewLine(Vector2 start, Vector2 finish, int width)
    {
        Line2D newLine = new Line2D();
        newLine.AddPoint(start);
        newLine.AddPoint(finish);
        newLine.DefaultColor = lineColor;
        newLine.Width = width;

        ConnectionGroup.AddChild(newLine);

    }

    public void DrawCall(Vector2[] locatons, double treshhold, double[,] netGraphWeights)
    {
        DrawAllComputers(locatons);
        DrawConnection(locatons, treshhold, netGraphWeights);
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
