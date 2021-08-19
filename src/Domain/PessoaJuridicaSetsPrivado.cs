using System;

namespace Domain
{
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
}
