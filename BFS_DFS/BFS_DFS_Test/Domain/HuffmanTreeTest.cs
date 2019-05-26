using BFS_DFS.Domain.Huffman;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BFS_DFS_Test.Domain
{
    [TestClass]
    public class HuffmanTreeTest
    {
        [TestMethod]
        public void Deveria_converter_texto_normal_para_texto_binario()
        {
            //normalVertices
            HuffmanVertex a = new HuffmanVertex('a');
            HuffmanVertex b = new HuffmanVertex('b');
            HuffmanVertex e = new HuffmanVertex('e');
            HuffmanVertex t = new HuffmanVertex('t');
            HuffmanVertex space = new HuffmanVertex(' ');

            //groupVertices
            HuffmanVertex spaceB = new HuffmanVertex(space, b);
            HuffmanVertex at = new HuffmanVertex(a, t);
            HuffmanVertex e_SpaceB = new HuffmanVertex(e, spaceB);
            HuffmanVertex mainVertex = new HuffmanVertex(at, e_SpaceB);

            //tree
            HuffmanTree tree = new HuffmanTree(mainVertex);

            var binaryText = tree.ConvertToBinary("bate bate");

            binaryText.Should().Be("111000110110111000110");
        }

        [TestMethod]
        public void Deveria_converter_texto_normal_quando_possuir_apenas_um_caractere()
        {
            HuffmanVertex a = new HuffmanVertex('a');

            HuffmanTree tree = new HuffmanTree(a);

            var normalText = tree.ConvertToBinary("aaaaaaaaaaaaaaaaaaaaaaa");

            normalText.Should().Be("00000000000000000000000");
        }

        [TestMethod]
        public void Deveria_converter_texto_binario_para_texto_normal()
        {
            //normalVertices
            HuffmanVertex a = new HuffmanVertex('a');
            HuffmanVertex b = new HuffmanVertex('b');
            HuffmanVertex e = new HuffmanVertex('e');
            HuffmanVertex t = new HuffmanVertex('t');
            HuffmanVertex space = new HuffmanVertex(' ');

            //groupVertices
            HuffmanVertex spaceB = new HuffmanVertex(space, b);
            HuffmanVertex at = new HuffmanVertex(a, t);
            HuffmanVertex e_SpaceB = new HuffmanVertex(e, spaceB);
            HuffmanVertex mainVertex = new HuffmanVertex(at, e_SpaceB);

            //tree
            HuffmanTree tree = new HuffmanTree(mainVertex);

            var binaryText = tree.ConvertToNormal("111000110110111000110");

            binaryText.Should().Be("bate bate");
        }

        [TestMethod]
        public void Deveria_converter_texto_binario_quando_possuir_apenas_um_caractere_independente_da_entrada()
        {
            HuffmanVertex a = new HuffmanVertex('a');

            HuffmanTree tree = new HuffmanTree(a);

            var normalText = tree.ConvertToNormal("00000000000000000000000");

            normalText.Should().Be("aaaaaaaaaaaaaaaaaaaaaaa");
        }
    }
}
