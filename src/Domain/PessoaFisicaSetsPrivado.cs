using System;

namespace Domain
{
    public class PessoaFisicaSetsPrivado
    {
        public PessoaFisicaSetsPrivado(Guid id, string nome, string sobrenome, string cpf, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
    }
}
