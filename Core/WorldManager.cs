using evolution.Core.Evolushion;
using evolution.Core.Evolushion.LowLevel.SelectionHandlers;
using Godot;
using System;

public class WorldManager : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    void DebugGetFitness(Genetic genetic)
    {
        (double score, string scores) = genetic.GetFitness();
        GD.Print(score);
        GD.Print("======");
        //GD.Print(scores);
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        Net net = new Net(30);
        FindShortestWay4PacketInNetCromosomeAnalyzer analyzer = new FindShortestWay4PacketInNetCromosomeAnalyzer(net.GetContainerLink());

        RankingSelectionHandler rankingSelection = new RankingSelectionHandler();

        Genetic genetic = new Genetic(rankingSelection, net.GetGeneticNodeValues(), analyzer);


        // tmp for debug
        DebugGetFitness(genetic);
        genetic.SelectionTest();
        DebugGetFitness(genetic);
        genetic.MutationTest();
        DebugGetFitness(genetic);
        genetic.BreedingTest();
        DebugGetFitness(genetic);

        //
        genetic.RunFullCycle();

        DebugGetFitness(genetic);
        GD.Print(genetic.GetMostFittedData());
        //
        // tmp for debug
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
