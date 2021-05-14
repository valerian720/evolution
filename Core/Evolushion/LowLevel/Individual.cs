using evolution.Core.Evolushion.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    public class Individual
    {
        // (содержит набор хромосом (генотип))
        public Chromosome[] genotype { get; private set; }
        MutationType mutation;
        GenotypeMixer genMixer;

        public double score { get; private set; }

        public Individual(MutationType _mutation, GenotypeMixer _genMixer, GeneValue[] allPossibleGenes, int cromosomeAmount, int cromosomeLength)
        {
            this.mutation = _mutation;
            this.genMixer = _genMixer;

            InitGenotype(allPossibleGenes, cromosomeAmount, cromosomeLength);

            score = 0;
        }

        public Individual(Chromosome[] genotypeAlfa, Chromosome[] genotypeBeta, MutationType _mutation, GenotypeMixer _genMixer)
        {
            this.mutation = _mutation;
            this.genMixer = _genMixer;

            this.genotype = genMixer.Mix(genotypeAlfa, genotypeBeta);
        }

        // ####################

        void InitGenotype(GeneValue[] allPossibleGenes, int cromosomeAmount, int cromosomeLength)
        {
            genotype = new Chromosome[cromosomeAmount];
            for (int i = 0; i < cromosomeAmount; i++)
            {
                genotype[i] = new Chromosome(allPossibleGenes, cromosomeLength);
            }
        }

        internal void Mutate(int mutationAmount, int mutationRateOutOf100)
        {
            foreach (var cromosome in genotype)
            {
                for (int i = 0; i < mutationAmount; i++)
                    {
                        cromosome.Mutate(mutation, mutationRateOutOf100);
                    }
            }
            
        }

        public double GetFit2TaskIndividual(CromosomeAnalyzer analyzer)
        {
            double ret = 0;
            foreach (var cromosome in genotype)
            {
                ret += cromosome.GetFit2TaskLokus(analyzer);
            }

            score = ret;

            return ret;
        }

        public Individual Crossbreed(Individual partner)
        {
            // тип мутации идет от производящего родителя (что за бред)
            return new Individual(this.genotype, partner.genotype, this.mutation, this.genMixer);
        }

        //=================================================
        // перегрузка функций сравнений
        public static bool operator >(Individual c1, Individual c2) => c1.score > c2.score;
        public static bool operator <(Individual c1, Individual c2) => c1.score < c2.score;
        public static bool operator >=(Individual c1, Individual c2) => c1.score >= c2.score;
        public static bool operator <=(Individual c1, Individual c2) => c1.score <= c2.score;

        internal string[] GetGenomeFingerprint()
        {
            string[] ret = new string[genotype.Length];

            for (int i = 0; i < genotype.Length; i++)
            {
                ret[i] = genotype[i].GetFingerprint();
            }
            return ret;
        }
    }

    public class IndividualScoreComparer : IComparer<Individual>
    {
        public int Compare(Individual x, Individual y)
        {
            return x.score.CompareTo(y.score);
        }
    }
}
