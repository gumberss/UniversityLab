using System.Collections.Generic;
using System.Linq;

namespace BFS_DFS.Domain
{
    public class Graph
    {
        public Graph(params Vertex[] vertices)
        {
            Vertices = vertices.ToList();
        }

        public List<Vertex> Vertices { get; private set; }

        public bool Contains(Vertex vertex)
        {
            return Vertices.Contains(vertex);
        }

        public bool AllVerticesVisited()
        {
            return Vertices.All(x => x.Visited);
        }

        public void ResetValues()
        {
            Vertices.ForEach(x =>
            {
                x.Distance = long.MaxValue;
                x.Previus = null;
                x.Visited = false;
            });
        }

        public Vertex GetCloserUnvisited()
        {
            return Vertices
                .Where(x => !x.Visited)
                .OrderBy(x => x.Distance)
                .FirstOrDefault();
        }

        public List<Tree> GenerateTree()
        {
            List<Tree> trees = new List<Tree>();

            trees.AddRange(Vertices
                .Where(x => x.Previus == null)
                .Select(x => new Tree(x)));

            foreach (var current in Vertices.Where(x => x.Previus != null))
            {
                Fill(current, trees);
            }

            return trees;
        }

        private Tree Fill(Vertex current, List<Tree> baseTree)
        {
            var findedTree = baseTree.Find(x => x.Contains(current.Previus));

            if (findedTree == null)
            {
                findedTree = Fill(current.Previus, baseTree);
            }

            return findedTree.AddSon(current);
        }

        public IEnumerable<Edge> GetAllEdges()
        {
            return Vertices.SelectMany(x => x.Edges).Distinct();
        }
    }
}
