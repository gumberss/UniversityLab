using BFS_DFS.Domain;
using BFS_DFS.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BFS_DFS_Test.Services
{
    [TestClass]
    public class BagProblemTest
    {
        [TestMethod]
        public void Deveria_encontrar_melhor_solucao_possivel_para_o_problema_da_mochila_com_memoizacao()
        {
            Item[] items = new Item[]{
                new Item("Arroz", 5, 2),
                new Item("feijão", 5, 5),
                new Item("Sal", 5, 1),
                new Item("Milho", 5, 1),
                new Item("Ervilha", 5, 1)
            };

            var bagProblem = new BagProblem();

            var result = bagProblem.ProcessWithMemoization(items, 10);

            result.Should().Be(7);
        }

        [TestMethod]
        public void Deveria_encontrar_melhor_solucao_possivel_para_o_problema_da_mochila()
        {
            Item[] items = new Item[]{
                new Item("Arroz", 5, 2),
                new Item("feijão", 5, 5),
                new Item("Sal", 5, 1),
                new Item("Milho", 5, 1),
                new Item("Ervilha", 5, 1)
            };

            var bagProblem = new BagProblem();

            var result = bagProblem.SolveProblem(items, 10, items.Length -1);

            result
                .Sum(x=> x.Value)
                .Should().Be(7);
        }
    }
}
