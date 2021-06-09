using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace evolution.Core.Util
{
    static class StaticWorldManagerDispenser
    {
        private static WorldManager instance;
        public static WorldManager GetWorldManager(Node node)
        {
            if (instance == null)
                instance = (WorldManager) node.GetTree().Root.GetChild(0).GetChild(0);//GetNode("/root/scene_main_node/node_wanted");
            return instance;
        }
    }
}
