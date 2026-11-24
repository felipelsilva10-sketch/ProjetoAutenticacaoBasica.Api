
using Microsoft.AspNetCore.Mvc;
using ProjetoAutenticacaoBasica.Api.models;
using ProjetoAutenticacaoBasica.Api.models.DTOs;
using ProjetoAutenticacaoBasica.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAutenticacaoBasica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassageirosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PassageirosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CriarPassageiroDto dto)
        {
            var passageiro = new Passageiro
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf
            };

            _context.Passageiros.Add(passageiro);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Passageiro criado com sucesso" });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassageiroinfoDto>>> GetPassageiros([FromQuery] string? nome)
        {
            var passageiros = await _context.Passageiros
                .AsNoTracking().Where(p => string.IsNullOrEmpty(nome) || p.Nome.Contains(nome))
                .OrderBy(p => p.Nome)
                .Select(p => new PassageiroinfoDto
                {
                    id = p.id,
                    Nome = p.Nome
                })
                .ToListAsync();

            return Ok(passageiros);
        }
        [HttpGet("{cpf}")]
        public async Task<ActionResult<PassageiroinfoDto>> GetPassageiroByCpf(string cpf)
        {
            var passageiro = await _context.Passageiros
                .AsNoTracking()
                .Where(p => p.Cpf == cpf)
                .Select(p => new PassageiroinfoDto
                {
                    id = p.id,
                    Nome = p.Nome
                })
                .FirstOrDefaultAsync();

            if (passageiro == null)
            {
                return NotFound(new { message = "Passageiro não encontrado" });
            }

            return Ok(passageiro);
        }
    }
}
