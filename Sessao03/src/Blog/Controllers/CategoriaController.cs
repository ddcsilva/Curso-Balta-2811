using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet("v1/categorias")]
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
        
        {
            var categorias = await context.Categorias.ToListAsync();

            return Ok(categorias);
        }

        [HttpGet("v1/categorias/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context)
        {
            var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost("v1/categorias/")]
        public async Task<IActionResult> PostAsync(
            [FromBody] Categoria model,
            [FromServices] BlogDataContext context)
        {
            try
            {
                await context.Categorias.AddAsync(model);
                await context.SaveChangesAsync();

                return Created($"v1/categorias/{model.Id}", model);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "01XE01 - Não foi possível incluir a categoria");
            }
            catch (Exception)
            {
                return StatusCode(500, "01XE99 - Falha interna no servidor");
            }
        }

        [HttpPut("v1/categorias/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] Categoria model,
            [FromServices] BlogDataContext context)
        {
            var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            if (categoria == null)
                return NotFound();

            categoria.Nome = model.Nome;
            categoria.Slug = model.Slug;

            context.Categorias.Update(categoria);
            await context.SaveChangesAsync();

            return Ok(categoria);
        }

        [HttpDelete("v1/categorias/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context)
        {
            var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            if (categoria == null)
                return NotFound();

            context.Categorias.Remove(categoria);
            await context.SaveChangesAsync();

            return Ok(categoria);
        }
    }
}
