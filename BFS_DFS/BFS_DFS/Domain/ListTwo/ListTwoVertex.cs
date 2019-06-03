namespace BFS_DFS.Domain.ListTwo
{
    public class ListTwoVertex : Vertex
    {
        public ListTwoVertex(string name) : base(name) { }

        public ListTwoVertex(string name, double toll) : this(name)
        {
            Toll = toll;
        }

        public double Toll { get; set; }
    }
}
