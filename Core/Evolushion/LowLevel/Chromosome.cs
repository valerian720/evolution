using evolution.Core.Evolushion.LowLevel;
using evolution.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    public class Chromosome
    {

        // (содержит последовательность генов (локус))
        List<GeneValue> lokus;

        public int Length { get => lokus.Count; }

        public Chromosome(GeneValue[] allPossibleGenes, int cromosomeLength)
        {
            RandomGenerateLokus(allPossibleGenes, cromosomeLength);
        }
        public Chromosome(List<GeneValue> _lokus)
        {
            lokus = _lokus;
        }

        private void RandomGenerateLokus(GeneValue[] allPossibleGenes, int cromosomeLength)
        {
            // full random 
            // в теории при должном количестве значений генов распределение будет по Гаусу
            lokus = new List<GeneValue>();
            for (int i = 0; i < cromosomeLength; i++)
            {
                lokus.Add(allPossibleGenes[StaticRandom.getInstance().Next(allPossibleGenes.Length-1)]);
            }
        }

        public Chromosome ReplaceGeneValue(int startPoint, List<GeneValue> values)
        {
            int normalLength = this.Length;
            lokus.InsertRange(startPoint, values);
            if (this.Length > normalLength)
            {
                lokus = lokus.GetRange(0, normalLength); // bruh, поидее никогда не должно срабатывать, но путь будет на всякий случай
            }
            return this;
        }

        public List<GeneValue> GetCromosomePart(int start, int finish)
        {
            return lokus.GetRange(start, finish-start+1);
        }

        public Chromosome Copy()
        {
            List<GeneValue> tmpLokus = new List<GeneValue>();
            foreach (var item in lokus)
            {
                tmpLokus.Add(item.Copy()); // bruh
            }
            return new Chromosome(tmpLokus);
        }

        public double GetFit2TaskLokus(CromosomeAnalyzer analyzer)
        {
            return analyzer.Analyze(this.lokus);
        }

        public void Mutate(MutationType mutation, int mutationRateOutOf100)
        {
            if (StaticRandom.getInstance().Next(100 - mutationRateOutOf100) == 0 && mutationRateOutOf100>0) // 100% случаев при 100 и 0% при 0
            {
                int rndVal = StaticRandom.getInstance().Next(this.Length - 1);
                lokus[rndVal] = mutation.Mutate(lokus[rndVal]);
            }
            
        }

        internal string GetFingerprint()
        {
            string ret = "|";
            foreach (var item in lokus)
            {
                ret += $"{item}|";
            }

            return ret;
        }
    }
}
