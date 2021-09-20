using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

using AgendaTelefones.Struct;
using AgendaTelefones.Enums;

namespace AgendaTelefones
{
    class Program
    {
        static int proximaInsercao = 0;
        static Contato[] contatos = new Contato[100];

        static void Main(string[] args)
        {
            Console.WriteLine(Teste());
        }

        static Contato Teste() 
        {
            var telefone = new Telefone("33", "39467890");
            var endereco = new Endereco("rua", "bairro", "cidade", "estado");
            
            var contato = new Contato(
                "t",
                "y",
                telefone,
                TipoContato.Celular,
                "test@example.com",
                endereco,
                DateTime.ParseExact("24/01/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                "novo contato"
                );
            
            return contato;
        }

        static void InserirContato()
        {
            if (proximaInsercao == 100)
            {
                Console.WriteLine("Agenda cheia, delete um contato.");
                return;
            }

            string opcoesContato = "0 - celular\n1 - trabalho\n2 - casa\n3 - principal\n";
            opcoesContato += "4 - pager\n5 - fax trabalho\n6 - fax casa\n7 - outro";

            var nome = PegarEntradaUsuario("Digite o nome:");
            var sobrenome = PegarEntradaUsuario("Digite o sobrenome:");
            var email = PegarEntradaUsuario("Digite o email:");
            
            var ddd = PegarEntradaUsuario("Digite o DDD do telefone:");
            var telefoneNumero = PegarEntradaUsuario("Digite o número do telefone:");
            var tipoContatoEntrada = PegarEntradaUsuario(opcoesContato);
            
            var rua = PegarEntradaUsuario("Digite a rua:");
            var bairro = PegarEntradaUsuario("Digite o bairro:");
            var cidade = PegarEntradaUsuario("Digite a cidade:");
            var estado = PegarEntradaUsuario("Digite o estado:");

            var dataNascimento = PegarEntradaUsuario("Digite a data de nascimento (dd/mm/aaaa):");
            var observacoes = PegarEntradaUsuario("Observações:");

            TipoContato tipoContato = (TipoContato) int.Parse(tipoContatoEntrada);

            Telefone telefone = new Telefone(ddd, telefoneNumero);
            Endereco endereco = new Endereco(rua, bairro, cidade, estado);
            Contato contato = new Contato(
                nome,
                sobrenome,
                telefone,
                tipoContato,
                email,
                endereco,
                DateTime.ParseExact(dataNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                observacoes
            );
            
            contatos[proximaInsercao++] = contato;
        }

        static void RemoverContato()
        {
            ImprimirContatos(contatos);

            var indice = int.Parse(PegarEntradaUsuario("Digite o índice do contato para remover"));

            if (indice > proximaInsercao) {
                Console.WriteLine("Entrada inválida");
                return;
            }

            contatos = contatos.Where((contato, i) => i != indice).ToArray();
            proximaInsercao--;
        }

        static Contato[] FiltrarPorNome(string nome)
        {
            return contatos
                .Where(contato => contato.Nome.Equals(nome))
                .ToArray();
        }

        static Contato[] FiltrarPorSobrenome(string sobrenome, Contato[] contatosLista)
        {
            return contatosLista
                .Where(contato => contato.Sobrenome.Equals(sobrenome))
                .ToArray();
        }

        static string PegarEntradaUsuario(string mensagem) 
        {
            Console.WriteLine(mensagem);
            Console.WriteLine();

            var entrada = Console.ReadLine();

            return entrada;
        }

        static void ImprimirContatos(Contato[] contatosLista)
        {
            Console.WriteLine("\n");

            for (int i = 0; i < contatosLista.Length; i++)
            {
                Console.WriteLine($"{i} - {contatosLista[i]}");
                Console.WriteLine("---------------------");
            }
        }

    }
}
