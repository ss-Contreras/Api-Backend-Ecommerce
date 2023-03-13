using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TIENDAAPIV01.Contexto;
using TIENDAAPIV01.Models;

namespace TIENDAAPIV01.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Route("GetProductos")]
        [HttpGet]
        public IActionResult GetProductos()
        {

            List<Productos> productos = _context.Productos.Include(p => p.Categorias).ToList();
            return Ok(productos);
        }

        [Route("GetProductosRango/{page}/{cantidad}")]
        [HttpGet]
        public IActionResult GetProductosRango(int page, int cantidad)
        {
            //List<Productos> productos = _context.Productos.Where(p => p.IdProducto > IdInicial)
            //                                              .Where(p => p.IdProducto < IdFinal)
            //                                              .ToList();

            List<Productos> productos = _context.Productos.ToList();

            List<Productos> productosRango = new List<Productos>();
            int n =0;
            foreach (var product in productos)
            {
                n=n+1;
                if (n <= page*cantidad && n>= (page-1)*cantidad) {
                    productosRango.Add(product);
                }
            }



            return Ok(productosRango);
        }

        [Route("GetProductoByIdCategoria/{IdCategoria}")]
        [HttpGet]
        public IActionResult GetProductoByIdCategoria(int IdCategoria)
        {
            List<Productos> productos = _context.Productos.Where(p => p.IdCategoria == IdCategoria).ToList();
            return Ok(productos);
        }
    }
}