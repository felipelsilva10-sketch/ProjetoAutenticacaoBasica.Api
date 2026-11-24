
using Microsoft.AspNetCore.Mvc;
using ProjetoAutenticacaoBasica.Api.models;
using ProjetoAutenticacaoBasica.Api.models.DTOs;
using ProjetoAutenticacaoBasica.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAutenticacaoBasica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var usuario = new Usuario
            {
                Nome = registerDto.nome,
                Username = registerDto.Username,
                Password = registerDto.Password,
                CreateAt = DateTime.Now
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok("Usuário registrado com sucesso!");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(loginDto loginDto)
        {
            var usuario = await 
                _context.Usuarios.FirstOrDefaultAsync(u => u.Username == loginDto.Username && u.Password == loginDto.Password);

            if (usuario == null)
            {
                return Unauthorized("Credenciais inválidas.");
            }

            return Ok("Login realizado com sucesso!");
        }
    }
}
