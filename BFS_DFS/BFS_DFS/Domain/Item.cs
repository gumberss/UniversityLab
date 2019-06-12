using System;

namespace BFS_DFS.Domain
{
    public class Item
    {
        public Item() { }

        public Item(string name, double weight, double value)
        {
            Name = name;
            Weight = weight;
            Value = value;
        }

        public String Name { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
    }
}
