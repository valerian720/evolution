using evolution.Core.Evolushion.LowLevel;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    class FindShortestWay4PacketInNetCromosomeAnalyzer : CromosomeAnalyzer
    {
        NetContainer netContainer;

        public FindShortestWay4PacketInNetCromosomeAnalyzer(NetContainer _netContainer)
        {
            this.netContainer = _netContainer;
        }

        public double Analyze(List<GeneValue> cromosomeDeobfiscated)
        {
            /*
             * семантическое значение последовательности генов: 
             * последовательность узлов по которому может идти пакет
             *
             * семантическое значение счета: 
             * общая длина предлагаемой последовательности узлов, ведь чем она меньше - тем более оптимальный получается путь (?)
             */
            GeneValue previous = null;
            double ret = 0;
            foreach (var item in cromosomeDeobfiscated)
            {
                //GD.Print((item as NodeValue).GetValue());

                if (previous != null)
                {
                    ret += netContainer.GetValue((previous as NodeValue).GetValue(), (item as NodeValue).GetValue());
                }

                previous = item;
            }
            return ret;
        }
    }
}
