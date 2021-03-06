using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    public class NodeValue : GeneValue
    {
        int nodeId;

        public NodeValue(int _nodeId)
        {
            nodeId = _nodeId;
        }

        public int GetValue()
        {
            return nodeId;
        }

        public GeneValue Copy() => new NodeValue(this.nodeId);

        public override string ToString()
        {
            return $"[ID: {nodeId}]";
        }
    }
}
