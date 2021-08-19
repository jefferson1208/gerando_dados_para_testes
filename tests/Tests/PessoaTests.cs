using Xunit;

namespace Tests
{
    [Collection(nameof(DadosAleatoriosCollection))]
    public class PessoaTests
    {
        private readonly DadosAleatorios _dadosAleatorios;
        public PessoaTests(DadosAleatorios dadosAleatorios)
        {
            _dadosAleatorios = dadosAleatorios;
        }

        [Fact]
        public void PessoaFisica()
        {
            //ARRANGE
            var pessoas = _dadosAleatorios.GerarListaPessoaFisica(quantidade: 50);

            //ACT

            //ASSERT
        }

        [Fact]
        public void PessoaFisicaSetsPrivado()
        {
            //ARRANGE
            var pessoas = _dadosAleatorios.GerarListaPessoaFisicaSetsPrivado(quantidade: 50);

            //ACT

            //ASSERT
        }

        [Fact]
        public void PessoaJurídica()
        {
            //ARRANGE
            var pessoas = _dadosAleatorios.GerarListaPessoaJuridica(quantidade: 50);

            //ACT

            //ASSERT
        }

        [Fact]
        public void PessoaJurídicaSetsPrivado()
        {
            //ARRANGE
            var pessoas = _dadosAleatorios.GerarListaPessoaJuridicaSetsPrivado(quantidade: 50);

            //ACT

            //ASSERT
        }

    }
}
