using Domain;
using System.Collections.Generic;

namespace Repository.Pessoas
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoa> ObterTodasPessoas();
        IEnumerable<Pessoa> ObterPessoaPorNomeEStatus(string nome, bool status);
    }
}
