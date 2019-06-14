using BFS_DFS.Domain;
using System.Linq;

namespace BFS_DFS.Services.ListTwo
{
    public class QuestionThree
    {
        private static BagProblem _bagProblem = new BagProblem();

        /// <summary>
        /// O algoritmo para quando:
        /// 1 - Todos os itens já estão dentro de um caminhão
        /// 2 - Quando Não há mais caminhões para colocar os itens
        /// No primeiro caso, o lucro perdido é 0 pois todos os itens foram colocados para a entrega
        /// No segundo caso, o algoritmo buscou colocar todos os itens dentro dos caminhões, porém 
        /// não conseguiu, então ao percorrer todos os caminhões e não encontrar mais espaço para colocar 
        /// alguns items, retorna tais itens como prejuizo pois não será possível entrega-lo
        /// </summary>
        /// <param name="items">Items para colocar nos caminhões</param>
        /// <param name="trucks">Caminhões com suas respectivas capacidades de carga</param>
        /// <returns></returns>
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
