namespace ProjetoAutenticacaoBasica.Api.models
{
    public class Voo
    {
        public int id { get; set; }
        public int Codigo { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public ICollection<Passagem> Passagens = new List<Passagem>();
    }
}
