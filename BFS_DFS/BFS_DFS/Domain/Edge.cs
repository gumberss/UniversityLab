namespace BFS_DFS.Domain
{
    public class Edge
    {
        public Edge(Vertex from, Vertex to, double weight, bool directed)
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

        public void ChangeWeight(double newWeight)
        {
            Weight = newWeight;
        }

        public double Weight { get; private set; }

        public Vertex From { get; private set; }

        public Vertex To { get; private set; }
    }
}
