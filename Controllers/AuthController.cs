using Microsoft.AspNetCore.Http;
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

    }
}
