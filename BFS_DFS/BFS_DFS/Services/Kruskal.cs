using BFS_DFS.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BFS_DFS.Services
{
    public class Kruskal
    {
        public ReadOnlyCollection<Edge> Process(ref Graph graph, Vertex startVertex)
        {
            if (startVertex == null)
                throw new BusinessException($"O vértice inicial não pode ser nulo");

            if (!graph.Contains(startVertex))
                throw new BusinessException($"O vértice inicial '{startVertex.Name}' não está presente no grafo");

            graph.ResetValues();

            List<Edge> smallerPath = new List<Edge>();
            Dictionary<Vertex, List<Vertex>> sequenceControl = new Dictionary<Vertex, List<Vertex>>();

            foreach (var vertex in graph.Vertices)
            {
                sequenceControl.Add(vertex, new List<Vertex> { vertex });
            }

            var allEdges = graph.GetAllEdges().OrderBy(x => x.Weight).ToList();

            foreach (var edge in allEdges)
            {
                if (!sequenceControl[edge.From].SequenceEqual(sequenceControl[edge.To]))
                {
                    smallerPath.Add(edge);

                    var combinedVertices = sequenceControl[edge.From].Union(sequenceControl[edge.To]).ToList();

                    foreach (var matchVertex in combinedVertices)
                    {
                        sequenceControl[matchVertex] = combinedVertices;
                    }
                }
            }

            return smallerPath.AsReadOnly();
        }
    }
}
