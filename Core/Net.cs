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

        public Net(int size)
        {
            netSize = size;
            container = new NetContainer(size);
        }

         

        public NetContainer GetContainerLink() => container;
    }
}
