namespace ByteBank.Agencias.DAL.Models
{
    public partial class Agencia
    {
        public string Numero { get; set; } = null!;
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
    }
}
