using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion.LowLevel.SelectionHandlers
{
    class RankingSelectionHandler : SelectionHandler
    {
        IndividualScoreComparer comparer = new IndividualScoreComparer();

        public void SelectPopulation(ref List<Individual> individuals, int count)
        {
            /* 
             * 1. сортировка от большего к меньшему
             * 2. удаление всех элементов не попавших под первые count штук
             */
            individuals.Sort(comparer);

            individuals = individuals.GetRange(0, count);
        }
    }
}
