using BFS_DFS.Domain;
using BFS_DFS.Services.ListTwo;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BFS_DFS_Test.Services.ListTwo
{
    [TestClass]
    public class QuestionOneTest
    {
        private Graph _graph;
        private QuestionOne _questionOne;
        private Vertex _a;
        private Vertex _b;
        private Vertex _c;
        private Vertex _d;

        public QuestionOneTest()
        {
            _a = new Vertex("a");
            _b = new Vertex("b") { Weight = 50 };//Toll
            _c = new Vertex("c") { Weight = 100 };//Toll
            _d = new Vertex("d");

            Edge ab = new Edge(_a, _b, 100, true);
            Edge ac = new Edge(_a, _c, 100, true);
            Edge cb = new Edge(_b, _d, 300, true);
            Edge cd = new Edge(_c, _d, 200, true);

            _graph = new Graph(_a, _b, _c, _d);

            _questionOne = new QuestionOne();
        }

        [TestMethod]
        public void Deveria_retornar_melhor_rota_para_a_lamborghini()
        {
            var fuelPrice = 6;
            var autonomy = 3;

            var bestRoute = _questionOne.Process(ref _graph, _a, _d, fuelPrice, autonomy);

            bestRoute.Pop().Should().Be(_a);
            bestRoute.Pop().Should().Be(_c);
            bestRoute.Pop().Should().Be(_d);
        }

        [TestMethod]
        public void Deveria_retornar_melhor_rota_para_o_hb20()
        {
            var fuelPrice = 3;
            var autonomy = 12;

            var bestRoute = _questionOne.Process(ref _graph, _a, _d, fuelPrice, autonomy);

            bestRoute.Pop().Should().Be(_a);
            bestRoute.Pop().Should().Be(_b);
            bestRoute.Pop().Should().Be(_d);
        }
    }
}
