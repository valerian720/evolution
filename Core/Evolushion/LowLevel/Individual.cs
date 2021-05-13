using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    class Individual
    {
        // (содержит набор хромосом (генотип))
        public Chromosome[] genotype { get; private set; }
        MutationType mutation;

        public Individual(MutationType _mutation, GeneValue[] allPossibleGenes, int cromosomeAmount, int cromosomeLength)
        {
            mutation = _mutation;
            InitGenotype(allPossibleGenes, cromosomeAmount, cromosomeLength);
        }

        public Individual(Chromosome[] genotypeAlfa, Chromosome[] genotypeBeta, MutationType _mutation)
        {
            mutation = _mutation;
            genotype = MixGenotype(genotypeAlfa, genotypeBeta);
        }

        // ####################

        void InitGenotype(GeneValue[] allPossibleGenes, int cromosomeAmount, int cromosomeLength)
        {
            genotype = new Chromosome[cromosomeAmount];
            for (int i = 0; i < cromosomeAmount; i++)
            {
                genotype[i] = new Chromosome();
            }
        }

        Chromosome[] MixGenotype(Chromosome[] genotypeAlfa, Chromosome[] genotypeBeta, int mixpointsAmount)
        {
            // TODO вынести в отдельный класс данный алгоритм
            Random rnd = new Random();

            /* 
             *
             *
             */
        }

        public int GetFit2TaskIndividual()
        {
            int ret = 0;
            foreach (var cromosome in genotype)
            {
                //ret += cromosome.GetFit2TaskLokus();
            }
            return ret;
        }

        public Individual Crossbreed(Individual partner)
        {
            // тип мутации идет от производящего родителя (что за бред)
            return new Individual(this.genotype, partner.genotype, this.mutation);
        }
    }
}
