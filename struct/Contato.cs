using System;
using AgendaTelefones.Enums;

namespace AgendaTelefones.Struct
{
    public struct Contato
    {
        public Contato(string nome, string sobrenome, Telefone telefone, TipoContato tipoContato,
            string email, Endereco endereco, DateTime dataNascimento, string observacoes)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
            TipoContato = tipoContato;
            Email = email;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            Observacoes = observacoes;
        }

        public string Nome { get; init; }
        public string Sobrenome { get; init; }
        public string Email { get; init; }
        public string Observacoes { get; init; }
        public TipoContato TipoContato { get; init; }
        public Telefone Telefone { get; init; }
        public Endereco Endereco { get; init; }
        public DateTime DataNascimento { get; init; }

        public override string ToString()
        {
            string contato = "";
            
            contato += $"nome: {Nome}\n";
            contato += $"sobrenome: {Sobrenome}\n";
            contato += $"email: {Email}\n";
            contato += $"telefone: {Telefone}\n";
            contato += $"endereço: {Endereco}\n";
            contato += $"data de nascimento: {DataNascimento.ToString("dd/MM/yyyy")}\n";
            contato += $"tipo: {TipoContato}\n";
            contato += $"observações: {Observacoes}";

            return contato;
        }
    }
}