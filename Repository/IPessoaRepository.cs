using Domain;
using System.Collections.Generic;

namespace Repository
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoa> ObterTodasPessoas();
        IEnumerable<Pessoa> ObterPessoaPorNomeEStatus(string nome, bool Ativo);
    }
}
