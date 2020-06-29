using Bogus;
using Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests.Asserts
{
    [TestClass]
    public class ManyDataTests
    {

        public ManyDataTests()
        {
        }

        [DataTestMethod()]
        [DynamicData(nameof(MetodoComOsDados), DynamicDataSourceType.Method)]
        public void AssertAreEqual(string name, Email email, DateTime ultimoAcesso)
        {
            //Act
            var pessoa = new Pessoa(name, email, ultimoAcesso);

            //Assert
            pessoa.Nome.Should().Equals(name);
            pessoa.Email.Should().BeEquivalentTo(email);
            pessoa.UltimoAcesso.Should().Equals(ultimoAcesso);
        }
        public static IEnumerable<object[]> MetodoComOsDados()
        {
            yield return new object[] { "Roberto Firmino", new Email("robertofirmino@gmail.com"), DateTime.Now };
            yield return new object[] { "Neymar da Silva ", new Email("neymardosparca@hotmail.com"), DateTime.Now };
        }
    }
}
