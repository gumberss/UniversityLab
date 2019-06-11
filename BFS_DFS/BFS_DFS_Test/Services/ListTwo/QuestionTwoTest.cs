using BFS_DFS.Domain;
using BFS_DFS.Services.ListTwo;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BFS_DFS_Test.Services.ListTwo
{
    [TestClass]
    public class QuestionTwoTest
    {
        private Graph _graph;
        private QuestionTwo _questionOne;
        private Vertex _a;
        private Vertex _b;
        private Vertex _c;
        private Vertex _d;
        private Vertex _e;

        public QuestionTwoTest()
        {
            _a = new Vertex("a");
            _b = new Vertex("b");
            _c = new Vertex("c");
            _d = new Vertex("d");
            _e = new Vertex("e");

            Edge ab = new Edge(_a, _b, 10, true);
            Edge ac = new Edge(_a, _c, 10, true);
            Edge ae = new Edge(_a, _e, 20, true);
            Edge ad = new Edge(_a, _d, 20, true);
            Edge cd = new Edge(_c, _d, 200, true);
            Edge ed = new Edge(_e, _d, 200, true);
            Edge be = new Edge(_b, _e, 200, true);
            Edge de = new Edge(_d, _e, 200, true);

            _graph = new Graph(_a, _b, _c, _d, _e);

            _questionOne = new QuestionTwo();
        }

        [TestMethod]
        public void Deveria_retornar_as_arestas_com_mais_de_3_incidencias_no_caminho_minimo()
        {
            (List<Vertex> vertices, double weight) = _questionOne.Process(_graph);

            vertices.Should().HaveCount(1);
            vertices.First().Should().Be(_a);
            weight.Should().Be(60);
        }
    }
}
