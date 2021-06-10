using evolution.Core.Evolushion.LowLevel;
using Godot;
using System;

namespace evolution.Core.Evolushion { 
    public class Genetic
    {
        // (содержит гиперпараметры)
        public int populationAmount = 100;
        public int cromosomeAmount = 1;
        public int cromosomeLength = 30;
         
        public int mutationAmount = 10;
        public int mutationRateOutOf100 = 50;
         
        public int selectionCount = 50;
         
        public int iterationCount = 250;

        private int currentIteration = 0;

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
                ProgressPopulation();
                //GD.Print(currentIteration);
            }
        }

        public void ProgressPopulation()
        {
            //if (currentIteration < iterationCount) // TODO
            {
                controller.ProgressPopulation();
                controller.GetFitness();

                currentIteration++;
            }
            
        }

        public int GetCurrentIteration()
        {
            return currentIteration;
        }

        public string GetMostFittedData()
        {
            return controller.GetMostFittedGenomeFingerprint();
        }

    }
}