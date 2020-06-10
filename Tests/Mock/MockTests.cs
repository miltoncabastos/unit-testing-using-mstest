using Bogus;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Mock
{
    [TestClass]
    public class MockTests
    {
        private readonly Faker _faker;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaService _pessoaService;

        public MockTests()
        {
            _faker = new Faker("pt_BR");
            _pessoaRepository = Substitute.For<IPessoaRepository>();
            _pessoaService = new PessoaService(_pessoaRepository);
        }

        [TestMethod("Mock Interface")]
        public void MockInterface()
        {
            //Act
            var retorno = _pessoaService.PessoaAtivaParaSistema(1);

            //Assert
            Assert.IsTrue(retorno);
        }

        [TestMethod("Setup Mock With ReturnsForAnyArgs")]
        public void SetupMockWithReturnsForAnyArgs()
        {
            //Arrange
            var pessoas = CriarListaDePessoas(DateTime.Today.AddDays(-29));
            pessoas.AddRange(CriarListaDePessoas(_faker.Date.Past(1)));

            _pessoaRepository.ObterTodasPessoas().ReturnsForAnyArgs(pessoas);

            //Act
            var pessoasAtivas = _pessoaService.ObterPessoasAtivas().ToList();

            //Assert
            Assert.AreEqual(100, pessoasAtivas.Count);
        }

        private List<Pessoa> CriarListaDePessoas(DateTime ultimoAcesso) =>
            new Faker<Pessoa>().CustomInstantiator(
                f => new Pessoa(f.Person.FullName, f.Internet.Email(f.Person.FirstName, f.Person.LastName), ultimoAcesso)).Generate(100);
    }
}
