using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace Exemplo.Nancy.WebApi.Tests
{
    [TestClass]
    public class ApiModuleTest
    {
        private RestClient client;

        [TestInitialize]
        public void Init()
        {
            client = new RestClient("http://localhost:34283");
        }

        // 0 - Versão
        [TestMethod]
        public void VersaoApi()
        {
            var request = new RestRequest("/api/version", Method.GET);
            var response = client.Execute(request);
            Assert.AreEqual(response.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual(response.Content, "{\"version\":\"1.0.0.0\"}");
        }

        // 1 - Listar todos os clientes:
        [TestMethod]
        public void ListaTodosClientes()
        {
            var request = new RestRequest("/api/clients", Method.GET);
            var response = client.Execute(request);
            Assert.AreEqual(response.ResponseStatus, ResponseStatus.Completed);
        }

        // 2 - Obter os dados de um cliente específico:
        [TestMethod]
        public void ObterDadosCliente()
        {
            var request = new RestRequest("/api/clients/1", Method.GET);
            var response = client.Execute(request);
            Assert.AreEqual(response.ResponseStatus, ResponseStatus.Completed);
        }

        // 3 - Cadastrar um novo cliente:
        [TestMethod]
        public void CadastrarCliente()
        {
            var request = new RestRequest("/api/clients/1", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                Nome = "Pedro Paulo Souze",
                CPF = "00000000000",
                DataNascimento = new DateTime(1960, 5, 1),
                NumeroCartao = "7415852496350001"
            });

            var response = client.Execute(request);
            Assert.AreEqual(response.ResponseStatus, ResponseStatus.Completed);
        }

        // 4 - Listar todos os estabelecimentos:
        [TestMethod]
        public void ListaTodosEstabelecimentos()
        {
            var request = new RestRequest("/api/establishments", Method.GET);
            var response = client.Execute(request);
            Assert.AreEqual(response.ResponseStatus, ResponseStatus.Completed);
        }

        // 5 - Obter os dados de um cliente específico:
        [TestMethod]
        public void ObterDadosEstabelecimento()
        {
            var request = new RestRequest("/api/establishments/1", Method.GET);
            var response = client.Execute(request);
            Assert.AreEqual(response.ResponseStatus, ResponseStatus.Completed);
        }

        // 6 - Cadastrar um novo estabelecimento:
        [TestMethod]
        public void CadastrarEstabelecimento()
        {
            var request = new RestRequest("/api/establishments/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                CNPJ = "60316817000103"
            });

            var response = client.Execute(request);
            Assert.AreEqual(response.ResponseStatus, ResponseStatus.Completed);
        }

        // 7 - Fazer um pagamento:
        [TestMethod]
        public void FazerPagamento()
        {
            var request = new RestRequest("/api/payments/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                IdCliente = 1,
                IdEstabelecimento = 1,
                Valor = 1000,
                Data = DateTime.Now
            });

            var response = client.Execute(request);
            Assert.AreEqual(response.ResponseStatus, ResponseStatus.Completed);
        }

        // 8 - Cancelar um pagamento:
        [TestMethod]
        public void CanclarPagamento()
        {
            var request = new RestRequest("/api/payments/1", Method.DELETE);
            var response = client.Execute(request);
            Assert.AreEqual(response.ResponseStatus, ResponseStatus.Completed);
        }

        // 9 - Listar todos os pagamentos de um estabelecimento:
        [TestMethod]
        public void ListaTodosPagamentosUmEstabelecimento()
        {
            var request = new RestRequest("/api/payments/1", Method.GET);
            var response = client.Execute(request);
            Assert.AreEqual(response.ResponseStatus, ResponseStatus.Completed);
        }
    }
}
