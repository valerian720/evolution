using Godot;

namespace evolution.Core.Net.NetTopologyExecutions
{
    class RingNetTopology : NetTopology
    {
        public double[,] CalculateNetGraphWeights(int size, Vector2[] locations, double veryHighValue)
        {
            double[,] netGraphWeights = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j && i == ((j-1)%size))
                    {

                        netGraphWeights[i, j] = Mathf.Abs(locations[i].DistanceTo(locations[j]));
                    }
                    else
                    {
                        netGraphWeights[i, j] = veryHighValue;
                    }

                }
            }
            return netGraphWeights;
        }
    }
}
