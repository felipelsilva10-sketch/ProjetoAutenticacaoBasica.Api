namespace ProjetoAutenticacaoBasica.Api.models
{
    public class Usuario
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
