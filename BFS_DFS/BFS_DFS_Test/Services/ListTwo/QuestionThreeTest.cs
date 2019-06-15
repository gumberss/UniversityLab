using BFS_DFS.Domain;
using BFS_DFS.Services.ListTwo;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BFS_DFS_Test.Services.ListTwo
{
    [TestClass]
    public class QuestionThreeTest
    {
        [TestMethod]
        public void Deveria_conseguir_colocar_todos_os_itens_nos_caminhoes_quando_peso_dos_itens_nao_superarem_a_soma_das_capacidades_dos_caminhoes()
        {
            Item[] items = new Item[]
            {
                new Item("Feijão", 5, 10),
                new Item("Batata", 3, 8),
                new Item("Abacate", 2, 6),
                new Item("Maça", 1, 5),
                new Item("Tomate", 6, 4),
            };

            Truck[] trucks = new Truck[]
            {
                new Truck(5),
                new Truck(8),
                new Truck(4),
                new Truck(5),
                new Truck(5)
            };

            QuestionThree questionThree = new QuestionThree();

            (Item[] notDeliveredItems, double lostProfit) = questionThree.Process(items, trucks);

            notDeliveredItems.Should().BeEmpty(because: "Todos os itens couberam nos caminhões");
            lostProfit.Should().Be(0, "Todos os itens couberam nos caminhões, não gerando projuízo");
        }

        [TestMethod]
        public void Deveria_retornar_o_menor_prejuizo_possivel_quando_nao_for_possivel_colocar_todos_os_itens_nos_caminhoes()
        {
            Item[] items = new Item[]
            {
                new Item("Feijão", 5, 10),
                new Item("Batata", 3, 8),
                new Item("Abacate", 2, 6),
                new Item("Maça", 1, 5),
                new Item("Tomate", 6, 4),
            };

            Truck[] trucks = new Truck[]
            {
                new Truck(4),
                new Truck(5),
                new Truck(6),
            };

            QuestionThree questionThree = new QuestionThree();

            (Item[] notDeliveredItems, double lostProfit) = questionThree.Process(items, trucks);

            notDeliveredItems.Should().HaveCount(1, because: "Nem todos os itens couberam nos caminhões");
            lostProfit.Should().Be(4, "Pois o tomate é o item mais pesado e que tráz menos retorno de lucro, então ficou de fora");
        }
    }
}
