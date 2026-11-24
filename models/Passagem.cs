namespace ProjetoAutenticacaoBasica.Api.models
{
    public class Passagem
    { public int id { get; set; }
        public int Vooid { get; set; }
        public int Passageiroid { get; set; }
        public int Assento { get; set; }
        public Voo? Voo { get; set; }
        public Passageiro? Passageiro { get; set; }
    }
}
