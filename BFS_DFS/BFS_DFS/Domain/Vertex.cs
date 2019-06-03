using System;
using System.Collections.Generic;

namespace BFS_DFS.Domain
{
    public class Vertex
    {
        public Vertex(String name)
        {
            Name = name;
            Previus = null;
            Distance = long.MaxValue;
            Visited = false;
            Edges = new List<Edge>();
        }

        public String Name { get; private set; }

        public Vertex Previus { get; set; }

        public double Distance { get; set; }

        public bool Visited { get; set; }

        public List<Edge> Edges { get; private set; }

        public double Weight { get; set; }

        public void AddEdge(Edge edge)
        {
            if (!Edges.Contains(edge))
                Edges.Add(edge);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
