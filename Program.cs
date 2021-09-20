﻿using System;
using AgendaTelefones.Struct;
using AgendaTelefones.Enums;

namespace AgendaTelefones
{
    class Program
    {
        static void Main(string[] args)
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
                new DateTime(2000, 10, 10),
                "novo contato"
                );

            Console.WriteLine(contato);
        }
    }
}
