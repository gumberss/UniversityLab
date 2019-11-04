using BFS_DFS.Domain;
using System.Linq;

namespace BFS_DFS.Services
{
    public class Prim
    {
        /// <summary>
        /// O algoritmo de Prim é (também) um caso especial do método genérico. 
        /// O algoritmo de Prim é semelhante ao algoritmo de Dijkstra
        /// </summary>
        /// <param name="graph">Grafo para encontrar o caminho mínimo</param>
        /// <param name="startVertex">Vertice inicial</param>
        /// <returns>Tamanho do caminho mínimo encontrado</returns>
        public double Process(ref Graph graph, Vertex startVertex)
        {
            if (startVertex == null)
                throw new BusinessException($"O vértice inicial não pode ser nulo");

            if (!graph.Contains(startVertex))
                throw new BusinessException($"O vértice inicial '{startVertex.Name}' não está presente no grafo");

            graph.ResetValues();

            startVertex.Distance = 0;

            while (!graph.AllVerticesVisited())
            {
                var closer = graph.GetCloserUnvisited();

                closer.Visited = true;

                foreach (var edge in closer.Edges)
                {
                    if (!edge.To.Visited && edge.Weight < edge.To.Distance)
                    {
                        edge.To.Previus = closer;
                        edge.To.Distance = edge.Weight;
                    }
                }
            }

            return graph.Vertices.Sum(x => x.Distance);
        }
    }
}
