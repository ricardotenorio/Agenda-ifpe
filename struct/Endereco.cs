namespace AgendaTelefones.Struct
{
    public struct Endereco
    {
        public Endereco(string rua, string bairro, string cidade, string estado)
        {
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public string Rua { get; init; }
        public string Bairro { get; init; }
        public string Cidade { get; init; }
        public string Estado { get; init; }

        public override string ToString() 
        {
            string endereco = "\n";
            
            endereco += $"\trua: {Rua}\n";
            endereco += $"\tbairro: {Bairro}\n";
            endereco += $"\tcidade: {Cidade}\n";
            endereco += $"\testado: {Estado}";

            return endereco;
        }
    }
}