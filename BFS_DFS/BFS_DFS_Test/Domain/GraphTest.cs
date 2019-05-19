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
    }
}
