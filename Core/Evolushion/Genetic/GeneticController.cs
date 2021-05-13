using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    class GeneticController
    {
        // (содержит и управляет списком особей (популяция), )
        Individual[] population;

        public void InitPopulation()
        {

        }
        public void ProgressPopulation()
        {

        }

        Individual Crossbreed(Individual alfa, Individual beta)
        {
            return alfa.Crossbreed(beta); // ?
        }
    }
}
