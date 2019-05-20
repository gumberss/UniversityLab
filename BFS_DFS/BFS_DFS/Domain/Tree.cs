using System.Collections.Generic;
using System.Linq;

namespace BFS_DFS.Domain
{
    public class Tree
    {
        public Vertex Vertex { get; set; }

        public List<Tree> Sons { get; set; }

        public Tree(Vertex vertex)
        {
            Vertex = vertex;
            Sons = new List<Tree>();
        }

        public Tree AddSon(Vertex vertex)
        {
            var sonTree = Sons.Find(x => x.Vertex == vertex);

            if (sonTree == null)
            {
                sonTree = new Tree(vertex);
                Sons.Add(sonTree);
            }

            return sonTree;
        }

        public bool Contains(Vertex vertex)
        {
            if (Vertex == vertex) return true;

            foreach (var son in Sons)
            {
                return son.Contains(vertex);
            }

            return false;
        }

    }
}
