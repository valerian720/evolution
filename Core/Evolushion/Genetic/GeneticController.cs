using evolution.Core.Evolushion.LowLevel;
using evolution.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    class GeneticController
    {
        int populationAmount;

        int mutationAmount;
        int mutationRateOutOf100;

        int selectionCount;

        public GeneticController(GeneValue[] possibleGeneValues, int _populationAmount, int cromosomeAmount, int cromosomeLength, int _mutationAmount, int _mutationRateOutOf100, int _selectionCount)
        {
            InitPopulation(_populationAmount, possibleGeneValues, cromosomeAmount, cromosomeLength);
            this.populationAmount = _populationAmount;
            this.mutationAmount = _mutationAmount;
            this.mutationRateOutOf100 = _mutationRateOutOf100;
            this.selectionCount = _selectionCount;
        }

        // (содержит и управляет списком особей (популяция), )
        List<Individual> population;

        public void InitPopulation(int populationAmount, GeneValue[] possibleGeneValues, int cromosomeAmount, int cromosomeLength)
        {
            MutationType mutation = new FullRandomMutation(possibleGeneValues); // TODO параметризировать тип мутации
            GenotypeMixer genMixer = new OnePointGenotypeMixer(); // TODO параметризировать тип смешивания генотипов

            population = new List<Individual>();
            for (int i = 0; i < populationAmount; i++)
            {
                population.Add( new Individual(mutation, genMixer, possibleGeneValues, cromosomeAmount, cromosomeLength));
            }
        }
        //
        internal void SelectionProcess()
        {
            foreach (var individual in population)
            {

                //individual.Mutate(mutationAmount, mutationRateOutOf100);
            }
        }


        internal void MutateAll()
        {
            foreach (var individual in population)
            {
                individual.Mutate(mutationAmount, mutationRateOutOf100);
            }
        }

        internal void BreedingPeriod()
        {
            // TODO 
            /* 
             * немного измененный алгоритм размножения 
             * в варианте, который был представлен преподавателем происходит замена родителей их детьми с измененными генами, 
             * при этом общая численность индивидов не меняется
             * 
             * поскольку я пользуюсь С# который сам управляет памятью то
             * я предлагаю что дети просто добавляются в пулл индивидов, при этом сохраняются и их родители
             * 
             * мб данная симуляция получится более жесткой но более эффективной и более воспреимчивой к овефиту // TODO
             * 
             * количество необходимых детей = общее количество индивидов с предыдущей итерации - размер группы, прошедших селекцию
             */

            int neededChildPopulation = populationAmount - population.Count;

            for (int i = 0; i < neededChildPopulation; i++)
            {
                population.Add(Crossbreed(population[StaticRandom.getInstance().Next(population.Count)], population[StaticRandom.getInstance().Next(population.Count)]));
            }

            /*
            // test
            int breedCount = 50;
            int selectedA;
            for (int i = 0; i < breedCount; i++)
            {
                selectedA = StaticRandom.getInstance().Next(population.Count);
                population[selectedA] = Crossbreed(population[selectedA], population[StaticRandom.getInstance().Next(population.Count)]);
            }
            */
        }
        //

        internal (double, string) GetFitness(CromosomeAnalyzer analyzer)
        {
            // get fitness of polulation to task

            /*
             * для того чтобы получить счет популяции
             * надо пройтись по всем особям, применив к каждой функцию изменения счета
             */
            double ret = 0;
            string populationScore  = "/";
            double score;
            foreach (var individual in population)
            {
                score = individual.GetFit2TaskIndividual(analyzer);
                ret += score;
                populationScore += $"{score}/";
            }

            return (ret, populationScore);
        }

        public void ProgressPopulation()
        {

        }

        Individual Crossbreed(Individual alfa, Individual beta)
        {
            // SEX
            return alfa.Crossbreed(beta); // ?
        }
    }
}
