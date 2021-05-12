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
        Chromosome[] genotype;
        MutationType mutation;

        public Individual(MutationType _mutation)
        {
            mutation = _mutation;
            InitGenotype();
        }
        void InitGenotype()
        {

        }

        public void GetFit2TaskIndividual()
        {

        }
    }
}
