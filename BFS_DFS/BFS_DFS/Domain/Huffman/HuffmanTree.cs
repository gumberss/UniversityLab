using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BFS_DFS.Domain.Huffman
{
    public class HuffmanTree
    {
        public HuffmanTree(HuffmanVertex mainVertex)
        {
            MainVertex = mainVertex;
        }

        public HuffmanVertex MainVertex { get; private set; }

        public IEnumerable<HuffmanVertex> GetAllVertices()
        {
            return MainVertex.GetAllVertices();
        }

        public String ConvertToText(String binaryText)
        {
            return "";
        }

        /// <summary>
        /// Assumiremos que quando o vértice principal da arvore possuir valor
        /// essa árvore é uma folha, sendo assim retornará 0
        /// para todos os caracteres passado na árvore binária
        /// </summary>
        public String ConvertToBinary(String text)
        {
            StringBuilder builder = new StringBuilder();

            if (MainVertex.Character != '\0')
                return new string('0', text.Length);

            foreach (var character in text)
            {
                var binaryPath = MainVertex.FindBinaryPath(character);

                builder.Append(new String(binaryPath.ToArray()));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Assumiremos que quando o vértice principal da arvore possuir valor
        /// essa árvore é uma folha, sendo assim retornará o valor do vertice principal
        /// para todos os caracteres passado na árvore binária
        /// </summary>
        public String ConvertToNormal(string binaryText)
        {
            StringBuilder builder = new StringBuilder();

            HuffmanVertex currentVertex = MainVertex;

            if (MainVertex.Character != '\0')
                return new string(MainVertex.Character, binaryText.Length);

            foreach (var bit in binaryText)
            {
                if (bit == '0')
                    currentVertex = currentVertex.Left;
                else
                    currentVertex = currentVertex.Right;

                if (currentVertex.Character != '\0')
                {
                    builder.Append(currentVertex.Character);

                    currentVertex = MainVertex;
                }
            }

            return builder.ToString();
        }
    }
}
