using Blog.Data;
using Blog.Models;
using Blog.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet("v1/categorias")]
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
        
        {
            try
            {
                var categorias = await context.Categorias.ToListAsync();

                return Ok(categorias);
            }
            catch (Exception)
            {
                return StatusCode(500, "01XE99 - Falha interna no servidor");
            }
        }

        [HttpGet("v1/categorias/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context)
        {
            try
            {
                var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

                if (categoria == null)
                    return NotFound();

                return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(500, "01XE99 - Falha interna no servidor");
            }
        }

        [HttpPost("v1/categorias/")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CriarCategoriaViewModel model,
            [FromServices] BlogDataContext context)
        {
            try
            {
                if (model is null)
                {
                    return BadRequest("01XE90 - Categoria Nula");
                }

                var categoria = new Categoria
                {
                    Id = 0, 
                    Nome = model.Nome,
                    Slug = model.Slug.ToLower()
                };

                await context.Categorias.AddAsync(categoria);
                await context.SaveChangesAsync();

                return Created($"v1/categorias/{categoria.Id}", categoria);
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
            try
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
            catch (DbUpdateException)
            {
                return StatusCode(500, "01XE02 - Não foi possível alterar a categoria");
            }
            catch (Exception)
            {
                return StatusCode(500, "01XE99 - Falha interna no servidor");
            }

        }

        [HttpDelete("v1/categorias/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context)
        {
            try
            {
                var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

                if (categoria == null)
                    return NotFound();

                context.Categorias.Remove(categoria);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "01XE03 - Não foi possível excluir a categoria");
            }
            catch (Exception)
            {
                return StatusCode(500, "01XE99 - Falha interna no servidor");
            }
        }
    }
}
