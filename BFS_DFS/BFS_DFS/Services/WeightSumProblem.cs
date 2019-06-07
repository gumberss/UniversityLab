using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS.Services
{
    public class Item
    {
        public String Name { get; set; }
        public double Weight { get; set; }
    }

    public class WeightSumProblem
    {
        
        public List<Item> Process(Item[] items, double maxWeight, long current)
        {
            if (current == -1) return new List<Item>();

            if (maxWeight < items[current].Weight)
                return Process(items, maxWeight, --current);
            else
            {
                var currentItem = items[current];
                var withMe = Process(items, maxWeight - currentItem.Weight, current - 1);
                withMe.Add(currentItem);

                var withoutMe = Process(items, maxWeight, current - 1);

                return withMe.Sum(x => x.Weight) > withoutMe.Sum(x => x.Weight) ? withMe : withoutMe;
            }
        }
    }
}
