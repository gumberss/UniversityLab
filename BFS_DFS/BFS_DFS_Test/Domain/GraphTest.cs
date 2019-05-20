using BFS_DFS.Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BFS_DFS_Test.Domain
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void Deveria_resetar_os_valores_dos_vertices_vinculados_ao_grafo()
        {
            Vertex a = new Vertex("a") { Distance = 100, Visited = true };
            Vertex b = new Vertex("b") { Distance = 200, Visited = true, Previus = a };
            Vertex c = new Vertex("b") { Distance = 300, Visited = true, Previus = b };

            Graph graph = new Graph(a, b, c);

            graph.ResetValues();

            new[] { a, b, c }
                .All(x => x.Previus == null && x.Distance == long.MaxValue && !x.Visited)
                .Should().BeTrue();
        }

        [TestMethod]
        public void Deveria_retornar_o_vertice_com_a_menor_distancia_ainda_nao_visitado()
        {
            Vertex a = new Vertex("a") { Distance = 100, Visited = true };
            Vertex b = new Vertex("b") { Distance = 200, Visited = false };
            Vertex c = new Vertex("b") { Distance = 300, Visited = false };
            Vertex d = new Vertex("b") { Distance = 400, Visited = false };

            Graph graph = new Graph(a, b, c, d);

            var closer = graph.GetCloserUnvisited();

            closer.Should()
                .Be(b, because: "o vértice a já foi visitado, então o b é o vertice com a menor distância não visitado");
        }

        [TestMethod]
        public void Deveria_criar_uma_arvore_para_cada_vertice_sem_anterior()
        {
            Vertex a = new Vertex("a");
            Vertex b = new Vertex("b") { Previus = a };
            Vertex c = new Vertex("c");

            Graph graph = new Graph(a, b, c);

            var trees = graph.GenerateTree();

            trees.Should().HaveCount(2, because: "O vertice 'a' e o vértice 'c' não possuem anteriores");
        }

        [TestMethod]
        public void Deveria_adicionar_um_filho_a_arvore_correta_quando_vertice_possui_um_pai()
        {
            Vertex a = new Vertex("a");
            Vertex b = new Vertex("b") { Previus = a };
            Vertex c = new Vertex("c");
            Vertex d = new Vertex("d") { Previus = a };
            Vertex e = new Vertex("e") { Previus = d };

            Graph graph = new Graph(a, b, c, d, e);

            var trees = graph.GenerateTree();

            trees.Should().HaveCount(2, because: "O vertice 'a' e o vértice 'c' não possuem anteriores");

            var aTree = trees.First();

            aTree.Sons.Should().HaveCount(2);
            aTree.Sons.First().Vertex.Should().Be(b);
            aTree.Sons.Last().Vertex.Should().Be(d);
            aTree.Sons.Last().Sons.Should().HaveCount(1);
            aTree.Sons.Last().Sons.First().Vertex.Should().Be(e);

        }
    }
}
