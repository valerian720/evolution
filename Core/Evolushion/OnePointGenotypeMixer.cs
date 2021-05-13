using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evolution.Core.Util;

namespace evolution.Core.Evolushion
{
    class OnePointGenotypeMixer : GenotypeMixer
    {
        public Chromosome[] Mix(Chromosome[] genotypeAlfa, Chromosome[] genotypeBeta)
        {

            int genotypeLen = genotypeAlfa.Length < genotypeBeta.Length ? genotypeAlfa.Length : genotypeBeta.Length;
            Chromosome[] ret = new Chromosome[genotypeLen];
            // перемешивает все хромосомы по парно, переламливая их в одной рандомной точке
            for (int i = 0; i < genotypeLen; i++)
            {
                int cromosomeLen = genotypeAlfa[i].Length < genotypeBeta[i].Length ? genotypeAlfa[i].Length : genotypeBeta[i].Length;

                int point = StaticRandom.getInstance().Next(cromosomeLen-1);
                ret[i] = genotypeAlfa[i].Copy().ReplaceGeneValue(point, genotypeBeta[i].GetCromosomePart(0, genotypeBeta[i].Length-1));
            }
            return ret;
        }
    }
}
