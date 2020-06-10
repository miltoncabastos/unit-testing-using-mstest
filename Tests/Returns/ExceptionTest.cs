using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Repository;
using Service;
using System;
using System.Linq;

namespace Tests.Returns
{
    [TestClass]
    public class ExceptionTest
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaService _pessoaService;

        public ExceptionTest()
        {
            _pessoaRepository = Substitute.For<IPessoaRepository>();
            _pessoaService = new PessoaService(_pessoaRepository);
        }

        [TestMethod("Setup Mock With Return Exception Use ReturnsForAnyArgs")]
        public void SetupMockReturnsExceptionForAnyArgs()
        {
            //Arrange
            _pessoaRepository.ObterTodasPessoas().ReturnsForAnyArgs(x => { throw new ArgumentException("Error Test"); });

            //Act
            var pessoasAtivas = _pessoaService.ObterPessoasAtivas().ToList();

            //Assert
            Assert.AreEqual("Error Test", pessoasAtivas.FirstOrDefault().Nome);
        }

        [TestMethod("Setup Mock With Return Exception Use Return")]
        public void SetupMockReturnException()
        {
            //Arrange
            _pessoaRepository.ObterTodasPessoas().Returns(x => { throw new ArgumentException("Error Test"); });

            //Act
            var pessoasAtivas = _pessoaService.ObterPessoasAtivas().ToList();

            //Assert
            Assert.AreEqual("Error Test", pessoasAtivas.FirstOrDefault().Nome);
        }

        [TestMethod("Setup Mock With Return Exception Use When Do")]
        public void SetupMockReturnExceptionUseWhenDo()
        {
            //Arrange
            _pessoaRepository
                .When(x => x.ObterTodasPessoas())
                .Do(x => throw new ArgumentException("Error Test"));
                
            //Act
            var pessoasAtivas = _pessoaService.ObterPessoasAtivas().ToList();

            //Assert
            Assert.AreEqual("Error Test", pessoasAtivas.FirstOrDefault().Nome);
        }
    }
}
