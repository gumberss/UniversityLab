using System.Collections.Generic;
using System.Linq;

namespace BFS_DFS.Domain.Huffman
{
    public class HuffmanVertex
    {
        public HuffmanVertex()
        {
            Character = default(char);
        }

        public HuffmanVertex(HuffmanVertex left, HuffmanVertex right) : this()
        {
            Left = left;
            Right = right;
        }

        public HuffmanVertex(char character)
        {
            Character = character;
            Frequency = 0;
        }

        public char Character { get; private set; }

        public long Frequency { get; private set; }

        public HuffmanVertex Left { get; private set; }

        public HuffmanVertex Right { get; private set; }

        internal IEnumerable<char> FindBinaryPath(char character)
        {
            if (this.Character == character)
                return Enumerable.Empty<char>();

                var leftPath = Left?.FindBinaryPath(character);

            if (leftPath != null)
                return new[] { '0' }.Concat(leftPath);

            var rightPath = Right?.FindBinaryPath(character);

            if (rightPath != null)
                return new[] { '1' }.Concat(rightPath);

            return null;
        }

        public IEnumerable<HuffmanVertex> GetAllVertices()
        {
            var leftSons = Left?.GetAllVertices() ?? Enumerable.Empty<HuffmanVertex>();
            var rightSons = Right?.GetAllVertices() ?? Enumerable.Empty<HuffmanVertex>();

            return new[] { this }.Union(leftSons).Union(rightSons);
        }

        public void IncrementFrequency()
        {
            Frequency++;
        }
    }
}
