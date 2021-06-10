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
        private readonly GeneValue[] allCromosomeValues;
        static private int duplicatePunnishmentMultiplyer = 99999;

        public FindShortestWay4PacketInNetCromosomeAnalyzer(NetContainer _netContainer, GeneValue[] _allCromosomeValues)
        {
            this.netContainer = _netContainer;
            this.allCromosomeValues = _allCromosomeValues;
        }

        public double Analyze(List<GeneValue> cromosomeDeobfiscated)
        {
            /*
             * семантическое значение последовательности генов: 
             * последовательность узлов по которому может идти пакет
             *
             * семантическое значение счета: 
             * общая длина предлагаемой последовательности узлов, ведь чем она меньше - тем более оптимальный получается путь (?)
             * 
             * так же наказывается повторное использование наименований узлов
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

            ret += CountDuplicatesGeneValue(cromosomeDeobfiscated) * duplicatePunnishmentMultiplyer;
            //CountDuplicatesGeneValue(new List<GeneValue> { allCromosomeValues[0], allCromosomeValues[0], allCromosomeValues[0], allCromosomeValues[1] });

            return ret;
        }

        private int CountDuplicatesGeneValue(List<GeneValue> inputList)
        {
            var hashmap = new Dictionary<string, int>();

            foreach (var possibleVal in allCromosomeValues)
            {
                //GD.Print(possibleVal.ToString());
                //init
                hashmap.Add(possibleVal.ToString(), 0);
            }

            foreach (var val in inputList)
            {
                //GD.Print(hashmap.TryGetValue(val, out int bruh)); 
                if(hashmap.TryGetValue(val.ToString(), out int bruh))
                    hashmap[val.ToString()] += 1;
            }

            var count = 0;
            foreach (var item in hashmap.Values)
            {
                if (item > 1)
                    count += (item - 1);
            }

            if (count == 0)
            {
                DevDumpData(hashmap);
            }
            //GD.Print(count);
            return count;
        }
        private void DevDumpData(Dictionary<string, int> hashmap )
        {
            foreach (var key in hashmap.Keys)
            {
                GD.Print(key.ToString(), " ", hashmap[key]);
            }

            throw new Exception();
        }
    }
}
