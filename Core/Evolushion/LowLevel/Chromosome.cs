using evolution.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    class Chromosome
    {

        // (содержит последовательность генов (локус))
        List<GeneValue> lokus;

        public int Length { get => lokus.Count; }

        public Chromosome()
        {
            GenerateLokus();
        }
        public Chromosome(List<GeneValue> _lokus)
        {
            lokus = _lokus;
        }

        private void GenerateLokus()
        {
            //TODO
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

        public int GetFit2TaskLokus()
        {
            int ret = 0;
            // TODO
            return ret;
        }

        private void Mutate(MutationType mutation)
        {
            int rndVal = StaticRandom.getInstance().Next(this.Length - 1);
            lokus[rndVal] = mutation.Mutate(lokus[rndVal]);
        }

    }
}
