using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion.LowLevel
{
    public interface CromosomeAnalyzer
    {
        double Analyze(List<GeneValue> cromosomeDeobfiscated);
    }
}
