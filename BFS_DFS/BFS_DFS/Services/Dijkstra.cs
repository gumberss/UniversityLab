using BFS_DFS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS.Services
{
    /// <summary>
    /// O algoritmo de Dijkstra resolve o problema de encontrar um problema de caminho
    ///mínimos de fonte única em um grafo G = (V, E, w) ponderados dirigidos ou não.Para
    ///esse algoritmo, as arestas/arcos não devem ter pesos negativos
    /// </summary>
    public class Dijkstra
    {
        public void Process(ref Graph graph, Vertex startVertex)
        {
            if (startVertex == null)
                throw new BusinessException($"O vértice inicial não pode ser nulo");

            if (!graph.Contains(startVertex))
                throw new BusinessException($"O vértice inicial '{startVertex.Name}' não está presente no grafo");

            graph.ResetValues();

            startVertex.Distance = 0;

            while (!graph.AllVerticesVisited())
            {
                Vertex closer = graph.GetCloserUnvisited();

                closer.Visited = true;

                foreach (var edge in closer.Edges.Where(x=> !x.To.Visited))
                {
                    if(edge.To.Distance > closer.Distance + edge.Weight)
                    {
                        edge.To.Distance = closer.Distance + edge.Weight;

                        edge.To.Previus = closer;
                    }
                }
            }
        }
    }
}
