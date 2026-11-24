
using Microsoft.AspNetCore.Mvc;
using ProjetoAutenticacaoBasica.Api.models;
using ProjetoAutenticacaoBasica.Api.models.DTOs;
using ProjetoAutenticacaoBasica.Api.Data;
using Microsoft.EntityFrameworkCore;


namespace ProjetoAutenticacaoBasica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VoosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CriarVooDto dto)
        {
            var voo = new Voo
            {
                Codigo = dto.Codigo,
                Origem = dto.Origem,
                Destino = dto.Destino
            };

            _context.Voos.Add(voo);
            await _context.SaveChangesAsync();

            return Ok("Voo criado com sucesso");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResumoVooDto>>> GetVoos()
        {
            var voos = await _context.Voos
                .AsNoTracking()
                .OrderBy(v => v.Codigo)
                .Select(v => new ResumoVooDto
                {
                    id = v.id,
                    Codigo = v.Codigo,
                    Trajeto = $"{v.Origem} - {v.Destino}"
                })
                .ToListAsync();

            return Ok(voos);
        }
        [HttpGet("{codigo/codigo}")]
        public async Task<ActionResult<VooManifestoDto>> GetVoo(int codigo)
        {
            var voo = await _context.Voos
                .AsNoTracking()
                .Where(v => v.Codigo == codigo)
                .Select(v => new VooManifestoDto
                {
                    Codigo = v.Codigo,
                    Id = v.id,
                    Origem = v.Origem,
                    Trajeto = $"{v.Origem} - {v.Destino}",
                    Passageiros = v.Passagens.Select(p => new PassageiroNoVooDto
                    {
                        assento = p.Assento,
                        Nome = p.Passageiro.Nome
                    }).ToList()
                })
                .ToListAsync();

            if (voo == null)
            {
                return NotFound(new { message = "Voo não encontrado" });
            }

            return Ok(voo);
        }
    }
}
