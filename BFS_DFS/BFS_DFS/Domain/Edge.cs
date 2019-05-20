namespace BFS_DFS.Domain
{
    public class Edge
    {
        public Edge(Vertex from, Vertex to, long weight, bool directed)
        {
            From = from;
            To = to;
            Weight = weight;

            if (directed)
                From.AddEdge(this);
            else
            {
                From.AddEdge(this);
                To.AddEdge(new Edge(to, from, Weight, true));
            }
        }

        public long Weight { get; private set; }

        public Vertex From { get; private set; }

        public Vertex To { get; private set; }
    }
}
