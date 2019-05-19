using System;
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
    }
}
