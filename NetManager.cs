using Godot;
using System;

public class NetManager : Node2D
{

    private PackedScene computer = (PackedScene)ResourceLoader.Load("res://Assets/Prefabs/Computer.tscn");

    private Node2D PCGroup = new Node2D();
    private Node2D ConnectionGroup = new Node2D();

    int collumnsCount = 5;
    int rowsCount = 4;

    int margin = 100;

    float koefX;
    float koefY;

    public override void _Ready()
    {
        AddChild(ConnectionGroup);
        AddChild(PCGroup);

        CalculateCoeffs();
        DrawAllComputers();
        DrawConnection();
    }

    void CalculateCoeffs()
    {
        koefX = (GetViewport().GetVisibleRect().Size.x-(margin*2))/ (collumnsCount-1);
        koefY = (GetViewport().GetVisibleRect().Size.y - (margin * 2)) / (rowsCount-1);
    }
    void DrawAllComputers()
        {
        for (int i = 0; i < collumnsCount; i++)
            {
                for (int j = 0; j < rowsCount; j++)
                {
                    Node2D newComputer = (Node2D)computer.Instance();
                    newComputer.Position = new Vector2(margin + koefX * i, margin + koefY * j);
                    PCGroup.AddChild(newComputer); 
                }
            
            }
        }

    public void DrawConnection()
    {
        Line2D newLine = new Line2D();
        newLine.AddPoint(new Vector2(0, 0));
        newLine.AddPoint(new Vector2(500, 500));
        newLine.DefaultColor = new Color(255, 0, 0);
        newLine.Width = 10;

        ConnectionGroup.AddChild(newLine);
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
