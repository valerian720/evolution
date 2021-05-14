using evolution.Core.Evolushion.LowLevel;
using Godot;
using System;

namespace evolution.Core.Evolushion { 
    public class Genetic
    {
        // (содержит гиперпараметры)
        int populationAmount = 100;
        int cromosomeAmount = 2;
        int cromosomeLength = 30;

        int mutationAmount = 10;
        int mutationRateOutOf100 = 50;

        int selectionCount = 50;

        int iterationCount = 250;

        GeneticController controller;

        public Genetic(SelectionHandler selection, GeneValue[] possibleGeneValues, CromosomeAnalyzer _analyzer)
        {
            Repopulate(selection, possibleGeneValues, _analyzer);
        }

        public void Repopulate(SelectionHandler selection, GeneValue[] possibleGeneValues, CromosomeAnalyzer _analyzer)
        {
            controller = new GeneticController(selection, possibleGeneValues, _analyzer, populationAmount, cromosomeAmount, cromosomeLength, mutationAmount, mutationRateOutOf100, selectionCount, iterationCount);
        }

        internal (double, string) GetFitness()
        {
            return controller.GetFitness(); // tmp for debug
        }

        internal void SelectionTest()
        {
            controller.SelectionProcess(); // tmp for debug
        }

        internal void MutationTest()
        {
            controller.MutateAll(); // tmp for debug
        }

        internal void BreedingTest()
        {
            controller.BreedingPeriod(); // tmp for debug
        }

        public void RunFullCycle()
        {
            for (int i = 0; i < iterationCount; i++)
            {
                controller.ProgressPopulation();
            }
        }

        public string GetMostFittedData()
        {
            return controller.GetMostFittedGenomeFingerprint();
        }

    }
}