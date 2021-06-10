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


    public WorldManager()
    {
        
    }

    void DebugGetFitness(Genetic genetic)
    {
        (double score, string scores) = genetic.GetFitness();
        GD.Print(score);
        GD.Print("======");
        GD.Print(scores);
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
        //genetic.RunFullCycle();

        //DebugGetFitness(genetic);
        //GD.Print(genetic.GetMostFittedData());
        //Regenerate();
        //
        // tmp for debug


    }

    // bruh
    public int PopulationAmount { get => genetic.populationAmount; set { genetic.populationAmount = value; } }
    public int CromosomeAmount { get => genetic.cromosomeAmount; set { genetic.cromosomeAmount = value; } }
    public int CromosomeLength { get => genetic.cromosomeLength; set { genetic.cromosomeLength = value; } }
    public int MutationAmount { get => genetic.mutationAmount; set { genetic.mutationAmount = value; } }
    public int MutationRateOutOf100 { get => genetic.mutationRateOutOf100; set { genetic.mutationRateOutOf100 = value; } }
    public int SelectionCount { get => genetic.selectionCount; set { genetic.selectionCount = value; } }
    public int IterationCount { get => genetic.iterationCount; set { genetic.iterationCount = value; } }

    public void Regenerate()
    {
        netDisplayManager.ClearScreen();

        net = new Net(10, 600, 400, netDisplayManager);
        analyzer = new FindShortestWay4PacketInNetCromosomeAnalyzer(net.GetContainerLink(), net.GetGeneticNodeValues());
        rankingSelection = new RankingSelectionHandler();


         genetic = new Genetic(rankingSelection, net.GetGeneticNodeValues(), analyzer);
    }

    internal String ProgressPopulation()
    {
         genetic.ProgressPopulation();
         return genetic.GetMostFittedData();
    }

    public int GetCurrentIteration()
    {
        return genetic.GetCurrentIteration();
    }
}
