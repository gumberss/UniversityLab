using BFS_DFS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS.Services
{
    /// <summary>
    /// There is memoization
    /// </summary>
    public class BagProblem
    {
        public double Process(Item[] items, double maxWeight)
        {
            var matrixColumns = (int)maxWeight;

            double[,] memoization = new double[items.Length, matrixColumns];

            for (int i = 0; i < matrixColumns; i++)
            {
                memoization[0, i] = 0;//ver se o i é na linha ou coluna
            }

            for (int i = 1; i < items.Length; i++)
            {
                for (int w = 0; w < maxWeight; w++)
                {
                    if (maxWeight < items[i].Weight)
                        memoization[i, w] = memoization[i - 1, w];
                    else
                    {
                        var currentItem = items[i];

                        var currentItemWeight = (int)currentItem.Weight;

                        var withMe = currentItem.Value + memoization[i - 1, w - currentItemWeight];

                        var withoutMe = memoization[i - 1, w];

                        memoization[i, w] = Math.Max(withMe, withoutMe);
                    }
                }
            }

            return memoization[items.Length, matrixColumns];
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

                return withMe.Sum(x => x.Value) > withoutMe.Sum(x => x.Value) ? withMe : withoutMe;
            }
        }
    }
}
