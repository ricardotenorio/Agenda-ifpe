namespace AgendaTelefones.struct
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
    }
}