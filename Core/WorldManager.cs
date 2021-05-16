using evolution.Core.Evolushion;
using evolution.Core.Evolushion.LowLevel.SelectionHandlers;
using Godot;
using System;

public class WorldManager : Node
{
    protected NetManager netDisplayManager = null;

    Genetic genetic = null;
    Net net = null;
    FindShortestWay4PacketInNetCromosomeAnalyzer analyzer = null;
    RankingSelectionHandler rankingSelection = null;

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
        netDisplayManager = new NetManager();
        AddChild(netDisplayManager);


        Regenerate();

        // tmp for debug
        //DebugGetFitness(genetic);
        //genetic.SelectionTest();
        //DebugGetFitness(genetic);
        //genetic.MutationTest();
        //DebugGetFitness(genetic);
        //genetic.BreedingTest();
        //DebugGetFitness(genetic);

        //
        genetic.RunFullCycle();

        DebugGetFitness(genetic);
        GD.Print(genetic.GetMostFittedData());
        //
        // tmp for debug

        
    }

    public void Regenerate()
    {
        netDisplayManager.ClearScreen();

        net = new Net(10, 600, 400, netDisplayManager);
        analyzer = new FindShortestWay4PacketInNetCromosomeAnalyzer(net.GetContainerLink());
        rankingSelection = new RankingSelectionHandler();


         genetic = new Genetic(rankingSelection, net.GetGeneticNodeValues(), analyzer);
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
