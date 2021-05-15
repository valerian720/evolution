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
        int idealPopulationAmount;
        List<Individual> population;

        CromosomeAnalyzer analyzer;

        int mutationAmount;
        int mutationRateOutOf100;

        int selectionCount;
        SelectionHandler selection;

        int iterationCount;
        int currentIteration = 0;

        IndividualScoreComparer comparer = new IndividualScoreComparer();

        public GeneticController(SelectionHandler _selection, GeneValue[] possibleGeneValues, CromosomeAnalyzer _analyzer, int _populationAmount, int cromosomeAmount, int cromosomeLength, int _mutationAmount, int _mutationRateOutOf100, int _selectionCount, int _iterationCount)
        {
            InitPopulation(_populationAmount, possibleGeneValues, cromosomeAmount, cromosomeLength);
            this.idealPopulationAmount = _populationAmount;

            this.analyzer = _analyzer;

            this.mutationAmount = _mutationAmount;
            this.mutationRateOutOf100 = _mutationRateOutOf100;

            this.selectionCount = _selectionCount;
            this.selection = _selection;

            this.iterationCount = _iterationCount;
        }

        // (содержит и управляет списком особей (популяция), )
        

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
            selection.SelectPopulation(ref population, selectionCount);
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

            int neededChildPopulation = idealPopulationAmount - population.Count;

            for (int i = 0; i < neededChildPopulation; i++)
            {
                // ORGY
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

        internal (double, string) GetFitness()
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
            GetFitness(); // оценка приспособленности особей популяции
            if (currentIteration <= iterationCount) // проверка условия
            {
                SelectionProcess(); // селекция
                BreedingPeriod(); // применение оператора скрещивания
                MutateAll(); // применение оператора мутации
            }
        }

        public string GetMostFittedGenomeFingerprint()
        {
            population.Sort(comparer);
            return $"Score={population.First().score}\n\n{String.Join("\n\n", population.First().GetGenomeFingerprint())}";
        }

        Individual Crossbreed(Individual alfa, Individual beta)
        {
            /* 
         ███████╗███████╗██╗  ██╗
         ██╔════╝██╔════╝╚██╗██╔╝
         ███████╗█████╗   ╚███╔╝ 
         ╚════██║██╔══╝   ██╔██╗ 
         ███████║███████╗██╔╝ ██╗
         ╚══════╝╚══════╝╚═╝  ╚═╝
            */
            return alfa.Crossbreed(beta); 
        }
    }
}
