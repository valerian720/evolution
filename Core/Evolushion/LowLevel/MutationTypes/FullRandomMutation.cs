using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    class FullRandomMutation:MutationType
    {
        // полностью рандомная мутация для гена

        GeneValue[] possibleOutcomes;
        Random rnd = new Random();

        public FullRandomMutation(GeneValue[] _possibleOutcomes)
        {
            possibleOutcomes = _possibleOutcomes;
        }

        public GeneValue Mutate(GeneValue toMutate)
        {
            // полный отрыв при проведении мутации
            return possibleOutcomes[rnd.Next(possibleOutcomes.Length-1)];
        }
    }
}
