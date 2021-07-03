using evolution.Core.Net;
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

        int awailableAreaX;
        int awailableAreaY;

        double[,] netGraphWeights;
        Vector2[] locations;

        static double veryHighValue = 99999;

        NetManager netDisplayManager;

        public NetContainer(int _size, int _awailableAreaX, int _awailableAreaY, NetManager _netDisplayManager, NetTopology topology)
        {
            size = _size;

            this.awailableAreaX = _awailableAreaX;
            this.awailableAreaY = _awailableAreaY;
            this.netDisplayManager = _netDisplayManager;

            GenFullRandomGraph();
            netGraphWeights = topology.CalculateNetGraphWeights(size, locations, veryHighValue);
            //CalculateNetGraphWeights();

            netDisplayManager.DrawCall(locations, 500, netGraphWeights); // ?
        }

        public void UpdateTopology(NetTopology topology)
        {
            netGraphWeights = topology.CalculateNetGraphWeights(size, locations, veryHighValue);
            //CalculateNetGraphWeights();
            netDisplayManager.DrawCall(locations, 500, netGraphWeights); // ?
        }

        void GenFullRandomGraph()
        {
            netGraphWeights = new double[size, size];
            locations = new Vector2[size];

            for (int i = 0; i < size; i++)
            {
                locations[i] = new Vector2(StaticRandom.getInstance().Next(awailableAreaX), StaticRandom.getInstance().Next(awailableAreaY));
            }

        }

        //void CalculateNetGraphWeights()
        //{
        //    for (int i = 0; i < size; i++)
        //    {
        //        for (int j = 0; j < size; j++)
        //        {
        //            if (i != j)
        //            {
        //                netGraphWeights[i, j] = Mathf.Abs( locations[i].DistanceTo(locations[j]));
        //            }
        //            else
        //            {
        //                netGraphWeights[i, j] = veryHighValue;
        //            }
        //        }
        //    }
        //}
        //
        void DisplayGraph()
        {

        }
        //

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
            if (A <= netGraphWeights.GetLength(0) && B <= netGraphWeights.GetLength(1))
            {
                return netGraphWeights[A, B];
            }
            else
                throw new ArgumentOutOfRangeException();
        }



    }

}
