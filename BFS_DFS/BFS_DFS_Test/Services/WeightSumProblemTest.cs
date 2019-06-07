using BFS_DFS.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BFS_DFS_Test.Services
{
    [TestClass]
    public class WeightSumProblemTest
    {
        [TestMethod]
        public void Deveria_encontrar_os_items_que_consigo_carregar_ate_o_peso_limite()
        {
            Item[] items = new Item[]
            {
                new Item { Name = "Arroz", Weight = 3 },
                new Item { Name = "Feijão", Weight = 4},
                new Item { Name = "Água", Weight = 2 },
                new Item { Name = "Pimenta", Weight = 5 },
                new Item { Name = "Abacate", Weight = 6 },
                new Item { Name = "Açucar", Weight = 7 }
            };

            var maxWeight = 15;

            var returnData = new WeightSumProblem().Process(items, maxWeight, items.Length - 1);

            returnData.Should().HaveCount(4);

            returnData.Sum(x => x.Weight).Should().Be(maxWeight);
        }
    }
}
