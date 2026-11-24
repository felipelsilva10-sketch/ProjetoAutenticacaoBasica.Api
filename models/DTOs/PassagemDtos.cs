namespace ProjetoAutenticacaoBasica.Api.models.DTOs
{
    public class PassagemDtos
    {
    }
    public class EmitirPassagemDto
    {
        public int Vooid { get; set; }
        public int Passageiroid { get; set; }
        public int Assento { get; set; }
    }
    public class PassagemDetalhesDto
    {
        public int id { get; set; }
        public int Codigovoo{ get; set; }
        public string Trajeto { get; set; }
        public string NomePassageiro { get; set; }
        public int Assento { get; set; }


    }
}
