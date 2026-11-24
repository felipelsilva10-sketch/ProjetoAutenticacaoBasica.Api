namespace ProjetoAutenticacaoBasica.Api.models.DTOs
{
    
    public class CriarVooDto
    {
        public int Codigo { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
    }
    public class ResumoVooDto
    {
        public int id { get; set; }
        public int Codigo { get; set; }
        public string Trajeto { get; set; }
    }
    public class PassageiroNoVooDto
    {
     public int assento { get; set; }
        public string Nome { get; set; }
       
    }
    public class VooManifestoDto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Origem { get; set; }
        public string Trajeto { get; set; }
        public List<PassageiroNoVooDto> Passageiros { get; set; }
    }
}
