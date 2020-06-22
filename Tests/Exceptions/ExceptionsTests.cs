using Bogus;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Exceptions
{
    [TestClass]
    public class ExceptionsTests
    {
        private readonly Faker _faker;

        public ExceptionsTests()
        {
            _faker = new Faker("pt_BR");
        }        

        [TestMethod("Exception with message")]
        public void ExceptionWithMessage()
        {
            //Arrange 
            var nome = string.Empty;
            var email = new Email(_faker.Internet.Email());
            var ultimoAcesso = _faker.Date.Past(2);

            //Act and Assert
            Assert.ThrowsException<ArgumentException>(
                action: () => new Pessoa(nome, email, ultimoAcesso),
                message: "O nome é inválido");
        }
    }
}
