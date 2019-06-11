using BFS_DFS.Domain;
using System.Collections.Generic;
using System.Linq;

namespace BFS_DFS.Services
{
    public class WeightSumProblem
    {
        public List<Item> Process(Item[] items, double maxWeight)
        {
            var limitIndex = items.Length - 1;

            return SolveProblem(items, maxWeight, limitIndex);
        }

        private List<Item> SolveProblem(Item[] items, double maxWeight, long current)
        {
            if (current == -1) return new List<Item>();

            if (maxWeight < items[current].Weight)
                return SolveProblem(items, maxWeight, --current);
            else
            {
                var currentItem = items[current];
                var withMe = SolveProblem(items, maxWeight - currentItem.Weight, current - 1);
                withMe.Add(currentItem);

                var withoutMe = SolveProblem(items, maxWeight, current - 1);

                return withMe.Sum(x => x.Weight) > withoutMe.Sum(x => x.Weight) ? withMe : withoutMe;
            }
        }
    }
}
