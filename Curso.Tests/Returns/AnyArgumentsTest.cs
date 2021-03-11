using Bogus;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Repository.Pessoas;
using Service.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Returns
{
    [TestClass]
    public class AnyArgumentsTest
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaService _pessoaService;

        public AnyArgumentsTest()
        {
            _pessoaRepository = Substitute.For<IPessoaRepository>();
            _pessoaService = new PessoaService(_pessoaRepository);
        }

        [TestMethod("Setup Mock With Any Arguments")]
        public void SetupMockWithAnyArguments()
        {
            //Arrange
            var pessoas = CriarListaDePessoas(DateTime.Today.AddDays(-29));

            _pessoaRepository.ObterPessoaPorNomeEStatus(Arg.Any<string>(), true).Returns(pessoas);

            //Act
            var pessoasAtivas = _pessoaService.ObterPessoasPorNomeAtivas("Teste").ToList();

            //Assert
            Assert.AreEqual(100, pessoasAtivas.Count);
        }

        [TestMethod()]
        public void DicasDoMiltao()
        {

            var pessoaA = new Pessoa("miltão", new Email("miltao@gmail.com"), DateTime.Today);
            var pessoaB = new Pessoa("fulana", new Email("fulana@hotmail.com"), DateTime.Today);

            //Arrange
            _pessoaRepository.ObterPessoaPorNomeEStatus(nome: Arg.Any<string>(), status: true).Returns(new List<Pessoa>() { pessoaA });
            _pessoaRepository.ObterPessoaPorNomeEStatus(nome: pessoaB.Nome, status: Arg.Any<bool>()).Returns(new List<Pessoa>() { pessoaB });


            //Act
            var pessoasTesteA = _pessoaService.ObterPessoasPorNomeAtivas("PessoaQueDeveRetornarMiltão").FirstOrDefault();
            var pessoasTesteB = _pessoaService.ObterPessoasPorNomeAtivas("fulana").FirstOrDefault();

            //Assert
            Assert.AreEqual(pessoasTesteA.Nome, pessoaA.Nome);
            Assert.AreEqual(pessoasTesteB.Nome, pessoaB.Nome);
        }

        [TestMethod("Setup Mock With Conditional Arguments")]
        public void SetupMockWithConditionalArguments()
        {
            //Arrange
            var pessoas = CriarListaDePessoas(DateTime.Today.AddDays(-29));

            _pessoaRepository.ObterPessoaPorNomeEStatus(Arg.Is<string>(x => x.Length >= 5), true).Returns(pessoas);

            //Act
            var pessoasAtivas = _pessoaService.ObterPessoasPorNomeAtivas("Teste").ToList();

            //Assert
            Assert.AreEqual(100, pessoasAtivas.Count);
        }

        private List<Pessoa> CriarListaDePessoas(DateTime ultimoAcesso) =>
            new Faker<Pessoa>().CustomInstantiator(
                f => new Pessoa(f.Person.FullName, new Email(f.Internet.Email()), ultimoAcesso)).Generate(100);
    }
}
