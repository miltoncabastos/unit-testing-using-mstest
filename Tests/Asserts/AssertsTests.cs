using Bogus;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Asserts
{
    [TestClass]
    public class AssertsTests
    {
        private readonly Faker _faker;

        public AssertsTests()
        {
            _faker = new Faker("pt_BR");
        }

        [TestMethod("Assert AreEqual")]
        public void AssertAreEqual()
        {
            //Arrange 
            var nome = "Milton Bastos";
            var email = "miltonbastos@gmail.com";
            var ultimoAcesso = DateTime.Today;

            //Act
            var pessoa = new Pessoa(nome, email, ultimoAcesso);

            //Assert
            Assert.AreEqual(expected: nome, actual: pessoa.Nome);
        }

        [TestMethod("Assert IsTrue")]
        public void AssertIsTrue()
        {
            //Arrange 
            var nome = _faker.Person.FullName;
            var email = _faker.Internet.Email();
            var ultimoAcesso = DateTime.Today;

            //Act
            var pessoa = new Pessoa(nome, email, ultimoAcesso);

            //Assert
            Assert.IsTrue(pessoa.Ativo);
        }

        [TestMethod("Assert IsFalse")]
        public void AssertIsFalse()
        {
            //Arrange 
            var nome = _faker.Person.FullName;
            var email = _faker.Internet.Email();
            var ultimoAcesso = _faker.Date.Past(1);

            //Act
            var pessoa = new Pessoa(nome, email, ultimoAcesso);

            //Assert
            Assert.IsFalse(pessoa.Ativo);
        }
    }
}
