using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public IEnumerable<Pessoa> ObterPessoasAtivas()
        {
            IEnumerable<Pessoa> pessoasAtivas;
            try
            {
                pessoasAtivas = _pessoaRepository.ObterTodasPessoas().Where(p => p.Ativo);
            }
            catch (ArgumentException e)
            {
                pessoasAtivas = MontarPessoaDeRetornoParaCatch(e);
            }

            return pessoasAtivas;
        }

        public IEnumerable<Pessoa> ObterPessoasPorNomeAtivas(string nome)
        {
            IEnumerable<Pessoa> pessoasAtivas;
            try
            {
                pessoasAtivas = _pessoaRepository.ObterPessoaPorNomeEStatus(nome, true);
            }
            catch (ArgumentException e)
            {
                pessoasAtivas = MontarPessoaDeRetornoParaCatch(e);
            }

            return pessoasAtivas;
        }

        private static IEnumerable<Pessoa> MontarPessoaDeRetornoParaCatch(ArgumentException e)
        {
            return new List<Pessoa>() { new Pessoa(e.Message, "teste@gmail.com", DateTime.Today) };
        }

        public bool PessoaAtivaParaSistema(long id) 
        {
            return true;
        }
    }
}
