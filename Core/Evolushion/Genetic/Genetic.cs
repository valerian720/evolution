using evolution.Core.Evolushion.LowLevel;
using Godot;
using System;

namespace evolution.Core.Evolushion { 
    public class Genetic
    {
        // (содержит гиперпараметры)
        int populationAmount = 100;
        int cromosomeAmount = 2;
        int cromosomeLength = 10;

        int mutationAmount = 10;
        int mutationRateOutOf100 = 50;

        int selectionCount = 50;

        GeneticController controller;
        CromosomeAnalyzer analyzer;

        public Genetic(GeneValue[] possibleGeneValues, CromosomeAnalyzer _analyzer)
        {
            Repopulate(possibleGeneValues);
            this.analyzer = _analyzer;
        }

        public void Repopulate(GeneValue[] possibleGeneValues)
        {
            controller = new GeneticController(possibleGeneValues, populationAmount, cromosomeAmount, cromosomeLength, mutationAmount, mutationRateOutOf100, selectionCount);
        }

        internal (double, string) GetFitness()
        {
            return controller.GetFitness(analyzer); // tmp for debug
        }

        internal void MutationTest()
        {
            controller.MutateAll();
        }

        internal void BreedingTest()
        {
            controller.BreedingPeriod();
        }
    }
}