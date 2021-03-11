using Domain;
using System;
using System.Collections.Generic;

namespace Repository.Pessoas
{
    public class PessoaRepository : IPessoaRepository
    {
        public IEnumerable<Pessoa> ObterTodasPessoas()
        {
            return new List<Pessoa>
            {
                new Pessoa("Miltão", new Email("miltao@gmail.com"), DateTime.Now.AddDays(-6)),
                new Pessoa("MiltãoDev", new Email("miltaodev@gmail.com"), DateTime.Now.AddDays(-2))
            };
        }

        public IEnumerable<Pessoa> ObterPessoaPorNomeEStatus(string nome, bool status)
        {
            return new List<Pessoa>();
        }

        
    }
}
