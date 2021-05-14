using evolution.Core.Util;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    class NetContainer
    {
        // ( содержит полносвязный неориентированный граф, методы для управления им, методы для экспорта / импорта )
        int size;

        double[,] netGraph;

        public NetContainer(int _size)
        {
            size = _size;
            GenFullRandomGraph();
        }

        void GenFullRandomGraph()
        {
            int min = 5;

            int max = 100;
            // tmp full random
            netGraph = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    netGraph[i, j] = (double)StaticRandom.getInstance().Next(min, max);
                    //netGraph[i, j] = 1;
                }
            }
        }

        public void UpdateGraph()
        {

        }

        public void ImportGraph()
        {

        }
        public void ExportGraph()
        {

        }

        public double GetValue(int A, int B)
        {
            if (A <= netGraph.GetLength(0) && B <= netGraph.GetLength(1))
            {
                return netGraph[A, B];
            }
            else
                throw new ArgumentOutOfRangeException();
        }

    }
}
