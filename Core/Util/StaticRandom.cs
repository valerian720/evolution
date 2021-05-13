using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Util
{
    class StaticRandom
    {
        private static Random instance;

        private StaticRandom()
        { }

        public static Random getInstance()
        {
            if (instance == null)
                instance = new Random();
            return instance;
        }
    }
}
