using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    public interface GenotypeMixer
    {
        Chromosome[] Mix(Chromosome[] genotypeAlfa, Chromosome[] genotypeBeta);
    }
}
