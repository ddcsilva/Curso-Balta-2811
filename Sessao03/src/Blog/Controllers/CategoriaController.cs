using Blog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet("v1/categorias")]
        public IActionResult Get([FromServices] BlogDataContext context)
        {
            var categorias = context.Categorias.ToList();
            return Ok(categorias);
        }
    }
}
