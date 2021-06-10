using System;
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

        public Net(int size, int awailableAreaX, int awailableAreaY, NetManager netDisplayManager)
        {
            this.netSize = size;
            container = new NetContainer(size, awailableAreaX, awailableAreaY, netDisplayManager);
        }

         

        public NetContainer GetContainerLink() => container;

        NodeValue[] localNodeValues;

        internal NodeValue[] GetGeneticNodeValues()
        {
            // выдает перечисление всех нод, без дырок
            if (localNodeValues == null)
            {
                localNodeValues = new NodeValue[netSize];
                for (int i = 0; i < netSize; i++)
                {
                    localNodeValues[i] = new NodeValue(i);
                }
            }
            
            return localNodeValues;
        }
    }
}
