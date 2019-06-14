using BFS_DFS.Domain;
using System.Linq;

namespace BFS_DFS.Services.ListTwo
{
    public class QuestionThree
    {
        private static BagProblem _bagProblem = new BagProblem();

        public (Item[] notDelivered, double lostProfit) Process(Item[] items, Truck[] trucks)
        {
            foreach (var truck in trucks.OrderBy(x => x.LoadCapacity))
            {
                if (!items.Any()) break;

                var loadedItems = _bagProblem.SolveProblem(items, truck.LoadCapacity, items.Length - 1);

                items = items.Except(loadedItems).ToArray();
            }

            return (items, items.Sum(x=> x.Value));
        }
    }
}
