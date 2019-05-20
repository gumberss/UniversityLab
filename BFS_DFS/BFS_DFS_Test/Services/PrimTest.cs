using BFS_DFS.Domain;
using BFS_DFS.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BFS_DFS_Test.Services
{
    [TestClass]
    public class PrimTest
    {
        [TestMethod]
        public void Deveria_lancar_excecao_quando_vertice_inicial_for_nulo()
        {
            Vertex startVertex = null;

            Graph graph = new Graph();

            Dijkstra dijkstra = new Dijkstra();

            Action action = () => dijkstra.Process(ref graph, startVertex);

            action.Should().ThrowExactly<BusinessException>()
                  .And.Message.Should().Be("O vértice inicial não pode ser nulo");
        }

        [TestMethod]
        public void Deveria_lancar_excecao_quando_vertice_inicial_nao_encontrado_dentro_do_grafo()
        {
            Vertex startVertex = new Vertex("Starter");

            Graph graph = new Graph(new Vertex("Another"));

            Dijkstra dijkstra = new Dijkstra();

            Action action = () => dijkstra.Process(ref graph, startVertex);

            action.Should().ThrowExactly<BusinessException>()
                  .And.Message.Should().Be("O vértice inicial 'Starter' não está presente no grafo");
        }

        [TestMethod]
        public void Deveria_colocar_a_distancia_do_vertice_inicial_como_zero_dentro_do_grafo()
        {
            Vertex startVertex = new Vertex("Starter");

            Graph graph = new Graph(startVertex);

            Dijkstra dijkstra = new Dijkstra();

            dijkstra.Process(ref graph, startVertex);

            graph.Vertices[0].Distance.Should().Be(0);
        }

        [TestMethod]
        public void Deveria_encontrar_a_arvore_geradora_minima()
        {
            Vertex a = new Vertex("a");
            Vertex b = new Vertex("b");
            Vertex c = new Vertex("c");
            Vertex d = new Vertex("d");
            Vertex e = new Vertex("e");

            Edge ab = new Edge(a, b, 5, false);
            Edge ac = new Edge(a, c, 3, false);
            Edge ad = new Edge(a, d, 7, false);
            Edge cb = new Edge(c, b, 8, false);
            Edge cd = new Edge(c, d, 2, false);
            Edge bd = new Edge(b, d, 2, false);
            Edge be = new Edge(b, e, 1, false);
            Edge de = new Edge(d, e, 3, false);

            Graph graph = new Graph(a, b, c, d, e);

            Prim prim = new Prim();

            var totalDistance = prim.Process(ref graph, b);

            totalDistance.Should().Be(8);

            a.Distance.Should().Be(3);
            b.Distance.Should().Be(0);
            c.Distance.Should().Be(2);
            d.Distance.Should().Be(2);
            e.Distance.Should().Be(1);

            a.Previus.Should().Be(c);
            b.Previus.Should().Be(null);
            c.Previus.Should().Be(d);
            d.Previus.Should().Be(b);
            e.Previus.Should().Be(b);

            new[] { a, b, c, d, e }.All(x => x.Visited).Should().BeTrue();
        }
    }
}
