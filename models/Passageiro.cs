namespace ProjetoAutenticacaoBasica.Api.models
{
    public class Passageiro
    { public int id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public ICollection<Passagem> Passagens =new List<Passagem>();
    }
}
