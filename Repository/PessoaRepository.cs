using Domain;
using System.Collections.Generic;

namespace Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        public IEnumerable<Pessoa> ObterTodasPessoas() => new List<Pessoa>();
        public IEnumerable<Pessoa> ObterPessoaPorNomeEStatus(string nome, bool status) => new List<Pessoa>();
    }
}
