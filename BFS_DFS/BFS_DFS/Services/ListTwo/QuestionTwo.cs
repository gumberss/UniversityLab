using BFS_DFS.Domain;
using System.Collections.Generic;
using System.Linq;

namespace BFS_DFS.Services.ListTwo
{
    public class QuestionTwo
    {
        /// <summary>
        /// O algoritmo de Kruskal tem a complexidade Θ(|E|log2 |E|) no pior caso,
        /// Levando em consideração o GroupBy O(|E|), where O(|E|) e o select O(|E|) 
        /// executados para encontrar os vertices com mais de três arestas incicentes 
        /// sobre eles, o algoritmo fica com a complexidade O(4|E|log2 |E|).
        /// Removendo as multiplicações por constante o algoritmo fica como O(|E|log2 |E|)
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public (List<Vertex> vertices, double weight) Process(Graph graph)
        {
            if (!graph.Vertices.Any())
                throw new BusinessException($"É necessário existir vértices no grafo");

            var startVertex = graph.Vertices.First();

            var kruskal = new Kruskal();

            var edges = kruskal.Process(ref graph, startVertex);

            var moreThanThreeEdges =
                edges.GroupBy(x => x.From)
                .Where(x => x.Count() > 3)
                .Select(x => x.Key)
                .ToList();

            return (moreThanThreeEdges, edges.Sum(x => x.Weight));
        }
    }
}
