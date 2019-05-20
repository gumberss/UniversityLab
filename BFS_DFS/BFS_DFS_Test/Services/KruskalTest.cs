using BFS_DFS.Domain;
using BFS_DFS.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BFS_DFS_Test.Services
{
    [TestClass]
    public class KruskalTest
    {
        [TestMethod]
        public void Deveria_lancar_excecao_quando_vertice_inicial_for_nulo()
        {
            Vertex startVertex = null;

            Graph graph = new Graph();

            Kruskal kruskal = new Kruskal();

            Action action = () => kruskal.Process(ref graph, startVertex);

            action.Should().ThrowExactly<BusinessException>()
                  .And.Message.Should().Be("O vértice inicial não pode ser nulo");
        }

        [TestMethod]
        public void Deveria_lancar_excecao_quando_vertice_inicial_nao_encontrado_dentro_do_grafo()
        {
            Vertex startVertex = new Vertex("Starter");

            Graph graph = new Graph(new Vertex("Another"));

            Kruskal kruskal = new Kruskal();

            Action action = () => kruskal.Process(ref graph, startVertex);

            action.Should().ThrowExactly<BusinessException>()
                  .And.Message.Should().Be("O vértice inicial 'Starter' não está presente no grafo");
        }

        [TestMethod]
        public void Deveria_processar_o_algoritmo_retornando_o_valor_do_menor_caminho_corretamente()
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

            Kruskal kruskal = new Kruskal();

            var totalDistance = kruskal.Process(ref graph, b);

            totalDistance.Should().Be(8);
        }
    }
}
