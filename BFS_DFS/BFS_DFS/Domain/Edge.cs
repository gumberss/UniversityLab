namespace BFS_DFS.Domain
{
    public class Edge
    {
        public Edge(Vertex from, Vertex to, long weight, bool directed) : this(from, to, directed)
        {
            Weight = weight;
        }

        public Edge(Vertex from, Vertex to, bool directed)
        {
            From = from;
            To = to;

            if (directed)
                From.AddEdge(this);
            else
            {
                From.AddEdge(this);
                To.AddEdge(new Edge(to, from, true));
            }
        }

        public long Weight { get; private set; }

        public Vertex From { get; private set; }

        public Vertex To { get; private set; }
    }
}
