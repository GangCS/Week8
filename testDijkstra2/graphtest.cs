using System;
using System.Collections.Generic;
using System.Text;

namespace testDijkstra2
{
    class graphtest : IWGraph<node>
    {
        node master;
        public graphtest(node master)
        {
            this.master = master;
        }
        public IEnumerable<node> Neighbors(node node)
        {
            foreach (var item in node.getFriends())
            {
                yield return item;
            }
        }

        public int Weight(node node)
        {
            return node.getW();
        }
    }
}
