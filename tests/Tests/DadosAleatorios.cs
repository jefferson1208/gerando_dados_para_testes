using Bogus;
using Bogus.Extensions.Brazil;
using Domain;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    [CollectionDefinition(nameof(DadosAleatoriosCollection))]
    public class DadosAleatoriosCollection: ICollectionFixture<DadosAleatorios> { }
    public class DadosAleatorios
    {
        public List<PessoaFisica> GerarListaPessoaFisica(int quantidade = 1)
        {
            var pessoas = new Faker<PessoaFisica>("pt_BR")
                .RuleFor(p => p.Id, v => v.Random.Guid())
                .RuleFor(p => p.Nome, v => v.Person.FirstName)
                .RuleFor(p => p.Sobrenome, v => v.Person.LastName)
                .RuleFor(p => p.Cpf, v => v.Person.Cpf())
                .RuleFor(p => p.Email, setter: (v, p) => v.Internet.Email(p.Nome, p.Sobrenome))
                .RuleFor(p => p.Telefone, v => v.Person.Phone);

            return pessoas.Generate(quantidade);
        }

        public List<PessoaFisicaSetsPrivado> GerarListaPessoaFisicaSetsPrivado(int quantidade = 1)
        {
            var pessoas = new Faker<PessoaFisicaSetsPrivado>("pt_BR")
                .CustomInstantiator(p => new PessoaFisicaSetsPrivado(p.Random.Guid(),
                    p.Person.FirstName,
                    p.Person.LastName,
                    p.Person.Cpf(), "", p.Person.Phone))
                .RuleFor(p => p.Email, (v, p) => v.Internet.Email(p.Nome, p.Sobrenome));

            return pessoas.Generate(quantidade);
        }

        public List<PessoaJuridica> GerarListaPessoaJuridica(int quantidade = 1)
        {
            var pessoas = new Faker<PessoaJuridica>("pt_BR")
                .RuleFor(p => p.Id, v => v.Random.Guid())
                    .RuleFor(p => p.Nome, v => v.Company.CompanyName())
                    .RuleFor(p => p.Cnpj, v => v.Company.Cnpj())
                    .RuleFor(p => p.Email, setter: (v, p) => v.Internet.Email(p.Nome))
                    .RuleFor(p => p.Telefone, v => v.Person.Phone);

            return pessoas.Generate(quantidade);
        }

        public List<PessoaJuridicaSetsPrivado> GerarListaPessoaJuridicaSetsPrivado(int quantidade = 1)
        {
            var pessoas = new Faker<PessoaJuridicaSetsPrivado>("pt_BR")
                .CustomInstantiator(p => new PessoaJuridicaSetsPrivado(p.Random.Guid(),
                    p.Company.CompanyName(),
                    p.Company.Cnpj(),
                    "",
                    p.Person.Phone))
                .RuleFor(p => p.Email, (v, p) => v.Internet.Email(p.Nome));

            return pessoas.Generate(quantidade);
        }
    }
}
