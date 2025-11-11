using System.Collections.Generic;
using System.Linq;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;

namespace test.Mocks
{
    public class VeiculoServicoMock : IVeiculoServico
    {
        private static List<Veiculo> veiculos = new List<Veiculo>
        {
            new Veiculo { Id = 1, Nome = "Gol", Marca = "Volkswagen", Ano = 2015 },
            new Veiculo { Id = 2, Nome = "Onix", Marca = "Chevrolet", Ano = 2020 },
        };

        public List<Veiculo> Todos(int pagina = 1, string nome = null, string marca = null)
        {
            var query = veiculos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(v => v.Nome.Contains(nome, System.StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(marca))
                query = query.Where(v => v.Marca.Contains(marca, System.StringComparison.OrdinalIgnoreCase));

            return query.ToList();
        }

        public Veiculo? BuscaPorId(int id)
        {
            return veiculos.FirstOrDefault(v => v.Id == id);
        }

        public void Incluir(Veiculo veiculo)
        {
            veiculo.Id = veiculos.Count + 1;
            veiculos.Add(veiculo);
        }

        public void Atualizar(Veiculo veiculo)
        {
            var existente = BuscaPorId(veiculo.Id);
            if (existente != null)
            {
                existente.Nome = veiculo.Nome;
                existente.Marca = veiculo.Marca;
                existente.Ano = veiculo.Ano;
            }
        }

        public void Apagar(Veiculo veiculo)
        {
            var existente = BuscaPorId(veiculo.Id);
            if (existente != null)
                veiculos.Remove(existente);
        }
    }
}
