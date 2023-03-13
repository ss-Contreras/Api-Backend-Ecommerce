using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIENDAAPIV01.Contexto;
using TIENDAAPIV01.Models;

namespace TIENDAAPIV01.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Route("Categorias")]
        [HttpGet]
        public IActionResult GetCategorias()
        {
            List<Categorias> categorias = _context.Categorias.ToList();
            return Ok(categorias);
        }
        [Route("Categorias2")]
        [HttpGet    ]
        public IActionResult GetCategorias2()
        {
            List<Categorias> categorias = _context.Categorias.ToList();
            return Ok(categorias);
        }
    }
}
