namespace AgendaTelefones.struct
{
    public struct Contato
    {
        public Contato(string nome, string sobrenome, Telefone telefone, string email,
            Endereco endereco, DateTime dataNascimento, string observacoes)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            Observacoes = observacoes;
        }

        public string Nome { get; init; }
        public string Sobrenome { get; init; }
        public string Email { get; init; }
        public string Observacoes { get; init; }
        public Telefone Telefone { get; init; }
        public Endereco Endereco { get; init; }
        public DateTime DataNascimento { get; init; }
    }
}