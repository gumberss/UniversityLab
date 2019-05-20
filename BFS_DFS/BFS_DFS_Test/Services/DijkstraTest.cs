using BFS_DFS.Domain;
using BFS_DFS.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BFS_DFS_Test.Services
{
    [TestClass]
    public class DijkstraTest
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
        public void Deveria_calcular_o_caminho_minimo_dos_vertices_corretamente_a_partir_de_um_vertice_inicial()
        {
            Vertex a = new Vertex("a");
            Vertex b = new Vertex("b");
            Vertex c = new Vertex("c");
            Vertex d = new Vertex("d");
            Vertex e = new Vertex("e");
            Vertex f = new Vertex("f");

            Edge ab = new Edge(a, b, 7, true);
            Edge ac = new Edge(a, c, 5, true);
            Edge cb = new Edge(c, b, 1, true);
            Edge cd = new Edge(c, d, 3, true);
            Edge ce = new Edge(c, e, 4, true);
            Edge bd = new Edge(b, d, 2, true);

            Graph graph = new Graph(a, b, c, d, e, f);

            Dijkstra dijkstra = new Dijkstra();

            dijkstra.Process(ref graph, a);

            a.Distance.Should().Be(0);
            b.Distance.Should().Be(6);
            c.Distance.Should().Be(5);
            d.Distance.Should().Be(8);
            e.Distance.Should().Be(9);
            f.Distance.Should().Be(long.MaxValue, because: "Não há aresta que alcance o vertice f");

            a.Previus.Should().Be(null, because: "É o primeiro vértice, não possui anterior");
            b.Previus.Should().Be(c);
            c.Previus.Should().Be(a);
            d.Previus.Should().Be(c);
            e.Previus.Should().Be(c);
            f.Previus.Should().Be(null, because: "Não há aresta que alcance o vertice f");

            new[] { a, b, c, d, e, f }.All(x => x.Visited).Should().BeTrue();
        }
    }
}
