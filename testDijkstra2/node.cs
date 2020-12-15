using System;
using System.Collections.Generic;
using System.Text;

namespace testDijkstra2
{
    class node
    {
        string name;
        int w;
        List<node> friends;
        public node(string name,int w)
        {
            this.name = name;
            this.w = w;
            friends = new List<node>();
        }
        public void addfriend(node x)
        {
            friends.Add(x);
        }
        public List<node> getFriends()
        {
            return friends;
        }
        public int getW()
        {
            return w;
        }
        public string getname()
        {
            return name;
        }
    }
}
