using BFS_DFS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS.Services.ListTwo
{
    public class QuestionOne
    {
        public Stack<Vertex> Process(ref Graph graph, Vertex startVertex, Vertex finalVertex, double fuelPrice, double carAutonomy)
        {
            if (startVertex == null)
                throw new BusinessException($"O vértice inicial não pode ser nulo");

            if (finalVertex == null)
                throw new BusinessException($"O vértice final não pode ser nulo");

            if (!graph.Contains(startVertex))
                throw new BusinessException($"O vértice inicial '{startVertex.Name}' não está presente no grafo");

            if (!graph.Contains(finalVertex))
                throw new BusinessException($"O vértice inicial '{finalVertex.Name}' não está presente no grafo");

            graph.GetAllEdges().ToList().ForEach(x => x.ChangeWeight(x.Weight / carAutonomy * fuelPrice + x.To.Weight));

            var dijkstra = new Dijkstra();

            dijkstra.Process(ref graph, startVertex);

            var bestRoute = new Stack<Vertex>();

            var currentVertex = finalVertex;

            while (currentVertex != null)
            {
                bestRoute.Push(currentVertex);
                currentVertex = currentVertex.Previus;
            }

            return bestRoute;
        }
    }
}
