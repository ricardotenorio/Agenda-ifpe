namespace AgendaTelefones.struct
{
    public struct Telefone
    {
        public Telefone(string ddd, string numero)
        {
            DDD = ddd;
            Numero = numero;
        }

        public string DDD { get; init; }
        public string Numero { get; init; }

        public override string ToString() 
        {
            return $"({DDD}) {Numero}";
        }
    }
}