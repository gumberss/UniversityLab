using BFS_DFS.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BFS_DFS_Test.Services
{
    [TestClass]
    public class HuffmanTreeGeneratorTest
    {

        /// <summary>
        /// Tree should be like:
        /// 
        ///                     Empty
        ///                   /       \
        ///             Empty           Empty
        ///            /     \         /      \
        ///          A         T     E          Empty
        ///                                    /      \
        ///                               (space)       B
        /// </summary>
        [TestMethod]
        public void Deveria_montar_a_estrutura_da_arvore_de_Huffman_corretamente()
        {
            String text = "bate bate";
            
            var huffmanTreeGenerator = new HuffmanTreeGenerator();

            var tree = huffmanTreeGenerator.GetTree(text);

            tree.MainVertex.Character.Should().Be('\0');

            //left
            tree.MainVertex.Left.Character.Should().Be('\0');
            tree.MainVertex
                .Left.Left
                .Character
                .Should().Be('a');

            tree.MainVertex
                .Left.Right
                .Character
                .Should().Be('t');

            tree.MainVertex
                .Left.Left.Right
                .Should().BeNull();

            tree.MainVertex
                .Left.Left.Left
                .Should().BeNull();

            tree.MainVertex
                .Left.Right.Left
                .Should().BeNull();

            tree.MainVertex
                .Left.Right.Right
                .Should().BeNull();

            //Right
            tree.MainVertex.Right.Character.Should().Be('\0');

            tree.MainVertex
                .Right.Right
                .Character.Should().Be('\0');

            tree.MainVertex
                .Right.Left
                .Character.Should().Be('e');

            tree.MainVertex
                .Right.Left.Left
                .Should().BeNull();

            tree.MainVertex
                .Right.Left.Right
                .Should().BeNull();

            tree.MainVertex
                .Right.Right.Right
                .Character.Should().Be('b');

            tree.MainVertex
                .Right.Right.Right.Left
                .Should().BeNull();

            tree.MainVertex
                .Right.Right.Right.Right
                .Should().BeNull();

            tree.MainVertex
                .Right.Right.Left
                .Character.Should().Be(' ');

            tree.MainVertex
                .Right.Right.Left.Left
                .Should().BeNull();

            tree.MainVertex
                .Right.Right.Left.Right
                .Should().BeNull();
        }

        [TestMethod]
        public void Deveria_preencher_corretamente_a_frequencia_das_letras_dentro_da_arvode_de_Huffman()
        {
            String text = "Pirulito que bate bate";

            var huffmanTreeGenerator = new HuffmanTreeGenerator();

            var tree = huffmanTreeGenerator.GetTree(text);

            var vertices = tree.GetAllVertices().ToList();

            vertices.Find(x => x.Character == 'P').Frequency.Should().Be(1);
            vertices.Find(x => x.Character == 'i').Frequency.Should().Be(2);
            vertices.Find(x => x.Character == 'r').Frequency.Should().Be(1);
            vertices.Find(x => x.Character == 'u').Frequency.Should().Be(2);
            vertices.Find(x => x.Character == 'l').Frequency.Should().Be(1);
            vertices.Find(x => x.Character == 't').Frequency.Should().Be(3);
            vertices.Find(x => x.Character == ' ').Frequency.Should().Be(3);
            vertices.Find(x => x.Character == 'q').Frequency.Should().Be(1);
            vertices.Find(x => x.Character == 'b').Frequency.Should().Be(2);
            vertices.Find(x => x.Character == 'a').Frequency.Should().Be(2);
            vertices.Find(x => x.Character == 'e').Frequency.Should().Be(3);
        }

        [TestMethod]
        public void Deveria_converter_texto_com_a_arvore_de_Huffman_gerada()
        {
            String text = "In computer science and information theory, " +
                "a Huffman code is a particular type of optimal prefix " +
                "code that is commonly used for lossless data compression. " +
                "The process of finding or using such a code proceeds by means " +
                "of Huffman coding, an algorithm developed by David A. " +
                "Huffman while he was a Sc.D. student at MIT, " +
                "and published in the 1952 paper 'A Method for " +
                "the Construction of Minimum - Redundancy Codes'";

            var huffmanTreeGenerator = new HuffmanTreeGenerator();

            var tree = huffmanTreeGenerator.GetTree(text);

            var binaryText = tree.ConvertToBinary(text);

            var normalText = tree.ConvertToNormal(binaryText);

            normalText.Should().Be(text);
        }
    }
}
