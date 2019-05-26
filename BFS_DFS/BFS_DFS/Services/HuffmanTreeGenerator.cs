using BFS_DFS.Domain.Huffman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS.Services
{
    public class HuffmanTreeGenerator
    {
        public HuffmanTree GetTree(String text)
        {
            var vertexList = new List<HuffmanVertex>();

            foreach (var textChar in text)
            {
                var currentCharVertex = vertexList.Find(x => x.Character == textChar);

                if (currentCharVertex == null)
                {
                    currentCharVertex = new HuffmanVertex(textChar);
                    vertexList.Add(currentCharVertex);
                }

                currentCharVertex.IncrementFrequency();
            }

            var ordenedVertexList = vertexList.OrderBy(x => x.Frequency);

            Queue<HuffmanVertex> queue = new Queue<HuffmanVertex>(ordenedVertexList);

            while (queue.Count > 1)
            {
                var left = queue.Dequeue();

                var right = queue.Dequeue();

                queue.Enqueue(new HuffmanVertex(left, right));
            };

            return new HuffmanTree(queue.Dequeue());
        }
    }
}
