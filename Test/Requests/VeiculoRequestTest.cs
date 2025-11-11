using System.Net;
using System.Text;
using System.Text.Json;
using minimal_api;
using minimal_api.Dominio.Entidades;

namespace Test.Request
{
    [TestClass]
    public class VeiculoRequestTest
    {
        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Setup.ClassInit(testContext);
        }

        [TestMethod]
        public async Task Deve_Retornar_Todos_Os_Veiculos()
        {
            // Act
            var response = await Setup.client.GetAsync("/veiculos");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var veiculos = JsonSerializer.Deserialize<List<Veiculo>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.IsNotNull(veiculos);
            Assert.IsTrue(veiculos.Count > 0);
        }

        [TestMethod]
        public async Task Deve_Incluir_Novo_Veiculo()
        {
            // Arrange
            var novoVeiculo = new Veiculo
            {
                Nome = "Civic",
                Marca = "Honda",
                Ano = 2022
            };

            var content = new StringContent(JsonSerializer.Serialize(novoVeiculo), Encoding.UTF8, "application/json");

            // Act
            var response = await Setup.client.PostAsync("/veiculos", content);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var veiculoCriado = JsonSerializer.Deserialize<Veiculo>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.IsNotNull(veiculoCriado);
            Assert.AreEqual("Civic", veiculoCriado.Nome);
        }

        [TestMethod]
        public async Task Deve_Buscar_Veiculo_Por_Id()
        {
            // Act
            var response = await Setup.client.GetAsync("/veiculos/1");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var veiculo = JsonSerializer.Deserialize<Veiculo>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.IsNotNull(veiculo);
            Assert.AreEqual(1, veiculo.Id);
        }
    }
}
