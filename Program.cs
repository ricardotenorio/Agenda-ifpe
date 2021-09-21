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
            var entrada = "";
            var opcoes = "";
            opcoes += "1 - Listar contatos\n";
            opcoes += "2 - Adicionar contato\n";
            opcoes += "3 - Remover contato\n";
            opcoes += "4 - Buscar por nome\n";
            opcoes += "5 - Buscar por nome completo\n";
            opcoes += "6 - Buscar por tipo\n";
            opcoes += "7 - Buscar por cidade\n";
            opcoes += "0 - Sair";
           
            do
            {
                entrada = PegarEntradaUsuario(opcoes);

                switch (entrada)
                {
                    case "1":
                        ImprimirContatos(contatos);
                        break;
                    case "2":
                        InserirContato();
                        break;
                    case "3":
                        RemoverContato();
                        break;
                    case "4":
                        BuscarNome();
                        break;
                    case "5":
                        BuscarNomeCompleto();
                        break;
                    case "6":
                        BuscarTipo();
                        break;
                    case "7":
                        BuscarCidade();
                        break;
                    default:
                        Console.WriteLine("Entrada Inválida!");
                        break;
                }    
            } while (entrada != "0");
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

            if (String.IsNullOrEmpty(nome)) 
            {
                Console.WriteLine("O nome não pode estar vazio");
                return;
            }

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

            if (indice > proximaInsercao || indice < 0) {
                Console.WriteLine("Entrada inválida");
                return;
            }


            for (int i = indice; i < contatos.Length - 1; i++)
            {
                contatos[i] = contatos[i + 1];
            }

            contatos[contatos.Length - 1] = new Contato();
            
            proximaInsercao--;
        }

        static void BuscarNome()
        {
            var nome = PegarEntradaUsuario("Digite o nome:");

            Contato[] contatosFiltrados = FiltrarPorNome(nome);

            ImprimirContatos(contatosFiltrados);
        }

        static void BuscarNomeCompleto()
        {
            var nome = PegarEntradaUsuario("Digite o nome:");
            var sobrenome = PegarEntradaUsuario("Digite o sobrenome:");

            Contato[] contatosFiltrados = FiltrarPorSobrenome(sobrenome, FiltrarPorNome(nome));

            ImprimirContatos(contatosFiltrados);
        }

        static void BuscarCidade()
        {
            var cidade = PegarEntradaUsuario("Digite o cidade:");

            Contato[] contatosFiltrados = FiltrarPorCidade(cidade);

            ImprimirContatos(contatosFiltrados);
        }

        static void BuscarTipo()
        {
            string opcoesContato = "0 - celular\n1 - trabalho\n2 - casa\n3 - principal\n";
            opcoesContato += "4 - pager\n5 - fax trabalho\n6 - fax casa\n7 - outro";

            TipoContato tipo = (TipoContato) int.Parse(PegarEntradaUsuario(opcoesContato));

            Contato[] contatosFiltrados = FiltrarPorTipo(tipo);

            ImprimirContatos(contatosFiltrados);
        }

        static Contato[] FiltrarPorNome(string nome)
        {
            return contatos
                .Where(contato => nome.Equals(contato.Nome))
                .ToArray();
        }

        static Contato[] FiltrarPorSobrenome(string sobrenome, Contato[] contatosLista)
        {
            return contatosLista
                .Where(contato => sobrenome.Equals(contato.Sobrenome))
                .ToArray();
        }

        static Contato[] FiltrarPorCidade(string cidade)
        {
            return contatos
                .Where(contato => cidade.Equals(contato.PegarCidade()))
                .ToArray();
        }

        static Contato[] FiltrarPorTipo(TipoContato tipoContato)
        {
            return contatos
                .Where(contato => contato.TipoContato == tipoContato)
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
                if (String.IsNullOrEmpty(contatosLista[i].Nome))
                {
                    break;
                }
                int diasAteAniversario = CalcularDiasParaAniversario(contatosLista[i].DataNascimento);
                
                Console.WriteLine($"{i} - {contatosLista[i]}");

                if (diasAteAniversario > 0) {
                    Console.WriteLine($"Faltam {diasAteAniversario} dia(s) para o aniversário");
                }

                Console.WriteLine("---------------------");
            }
        }

        static int CalcularDiasParaAniversario(DateTime nascimento)
        {
            int faltam = 0;
            
            DateTime hoje = DateTime.Today;

            if (CorrigirBissexto(hoje, nascimento)) {
                faltam++;
            }
            
            hoje = hoje.AddYears(-hoje.Year + 1);
            nascimento = nascimento.AddYears(-nascimento.Year + 1);

            faltam += nascimento.Subtract(hoje).Days;

            return faltam;
        }

        static bool CorrigirBissexto(DateTime hoje, DateTime nascimento)
        {
            bool ehBissexto = false;
            bool limite = false;

            ehBissexto = DateTime.IsLeapYear(hoje.Year);
            limite = hoje.Month < 3 && hoje.Day <= 28
                && nascimento.Month > 2;

            return ehBissexto && limite;
        }

    }
}
