# Gerando dados aleatórios para testes com o pacote bogus
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## 1 - Pacote
```bash
Install-Package Bogus
```
## 2 - Classe PessoaFisica com propriedades com set privado
```CSharp
    public class PessoaJuridicaSetsPrivado
    {
        public PessoaJuridicaSetsPrivado(Guid id, string nome, string cnpj, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Cnpj = cnpj;
            Email = email;
            Telefone = telefone;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
    }
```
### 2.1 Gerando dados aleatórios
```CSharp
var pessoas = new Faker<PessoaFisicaSetsPrivado>("pt_BR")
                .CustomInstantiator(p => new PessoaFisicaSetsPrivado(p.Random.Guid(),
                    p.Person.FirstName,
                    p.Person.LastName,
                    p.Person.Cpf(), "", p.Person.Phone))
                .RuleFor(p => p.Email, (v, p) => v.Internet.Email(p.Nome, p.Sobrenome));

return pessoas.Generate();
```
## 3 - Classe PessoaFisica sem construtor
```CSharp
    public class PessoaFisica
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
```
### 3.1 Gerando dados aleatórios
```CSharp
var pessoas = new Faker<PessoaFisica>("pt_BR")
                .RuleFor(p => p.Id, v => v.Random.Guid())
                .RuleFor(p => p.Nome, v => v.Person.FirstName)
                .RuleFor(p => p.Sobrenome, v => v.Person.LastName)
                .RuleFor(p => p.Cpf, v => v.Person.Cpf())
                .RuleFor(p => p.Email, setter: (v, p) => v.Internet.Email(p.Nome, p.Sobrenome))
                .RuleFor(p => p.Telefone, v => v.Person.Phone);

return pessoas.Generate();
```
## 4 - Classe PessoaJurídica com propriedades com set privado
```CSharp
    public class PessoaJuridicaSetsPrivado
    {
        public PessoaJuridicaSetsPrivado(Guid id, string nome, string cnpj, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Cnpj = cnpj;
            Email = email;
            Telefone = telefone;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
    }
```
### 4.1 Gerando dados aleatórios
```CSharp
var pessoas = new Faker<PessoaJuridicaSetsPrivado>("pt_BR")
                .CustomInstantiator(p => new PessoaJuridicaSetsPrivado(p.Random.Guid(),
                    p.Company.CompanyName(),
                    p.Company.Cnpj(),
                    "",
                    p.Person.Phone))
                .RuleFor(p => p.Email, (v, p) => v.Internet.Email(p.Nome));

return pessoas.Generate();
```
## 5 - Classe PessoaJurídica sem construtor
```CSharp
    public class PessoaJuridica
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
```
### 5.1 Gerando dados aleatórios
```CSharp
var pessoas = new Faker<PessoaJuridica>("pt_BR")
                .RuleFor(p => p.Id, v => v.Random.Guid())
                    .RuleFor(p => p.Nome, v => v.Company.CompanyName())
                    .RuleFor(p => p.Cnpj, v => v.Company.Cnpj())
                    .RuleFor(p => p.Email, setter: (v, p) => v.Internet.Email(p.Nome))
                    .RuleFor(p => p.Telefone, v => v.Person.Phone);

return pessoas.Generate();
```
## Observações
É possível passar uma quantidade desejada para o método "Generate()", gerando assim várias entidades para teste. Ex:
```CSharp
var quantidadeDesejada = 100;
var pessoas = new Faker<PessoaJuridica>("pt_BR")

pessoas.Generate(quantidadeDesejada);
```
Também é possível gerar uma informação com base em outra já gerada. Por exemplo, um e-mail com base em um nome. Ex:

### Classe sem construtor
```CSharp
var pessoas = new Faker<PessoaJuridica>("pt_BR")
                    .RuleFor(p => p.Nome, v => v.Company.CompanyName())
                    .RuleFor(p => p.Email, setter: (v, p) => v.Internet.Email(p.Nome))

return pessoas.Generate();
```
### Classe com construtor
No construtor o e-mail é passado como string vazia, e ao final do CustomInstantiator é adicionado um RuleFor para definir o e-mail com base no nome gerado. 
```CSharp
var pessoas = new Faker<PessoaJuridicaSetsPrivado>("pt_BR")
                .CustomInstantiator(p => new PessoaJuridicaSetsPrivado(p.Random.Guid(),
                    p.Company.CompanyName(),
                    p.Company.Cnpj(),
                    "", // aqui não passamos o e-mail
                    p.Person.Phone))
                .RuleFor(p => p.Email, (v, p) => v.Internet.Email(p.Nome));

return pessoas.Generate();
```
## 6 - Tecnologias
<div style="display: inline_block"><br>
  <img align="center" alt="Jeferson-Netcore" height="30" width="40" src="https://github.com/devicons/devicon/blob/master/icons/dotnetcore/dotnetcore-original.svg">
  <img align="center" alt="Jeferson-Csharp" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg">
</div>
