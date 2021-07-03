using evolution.Core.Evolushion;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Net
{
    public interface NetTopology
    {
        double[,] CalculateNetGraphWeights(int size, Vector2[] locations, double veryHighValue);
    }
}
