﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    class Net
    {
        // (содержит гиперпараметры)
        int netSize;

        NetContainer container;

        public Net(int size)
        {
            netSize = size;
            container = new NetContainer(size);
        }

         

        public NetContainer GetContainerLink() => container;

        internal NodeValue[] GetGeneticNodeValues()
        {
            // выдает перечисление всех нод, без дырок
            NodeValue[] ret = new NodeValue[netSize];
            for (int i = 0; i < netSize; i++)
            {
                ret[i] = new NodeValue(i);
            }
            return ret;
        }
    }
}
