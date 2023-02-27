using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController] //Para que sea controlador
    [Route("/api/countries")] //Todas las peticiones que haga con "/api/countries" llegaran a este controlador
    public class CountriesController : ControllerBase //heredamos de controllerBase para que sea controlador
    {
        public readonly DataContext _context;

        //Constructor
        public CountriesController(DataContext context)
        {
            _context = context;
        }

        
        
        //metodo para insertar datos con post
        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Add(country);//adicionar dato a la base de  _context es la base de datos
            await _context.SaveChangesAsync(); //grabamos los datos realmente
            return Ok(country); //respuesta del guardado 200 si se guardo bien
        }

        //metodo para obtener todos datos
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        //metodo para obtener un dato
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        //metodo para editar 
        [HttpPut]
        public async Task<ActionResult> PutAsync(Country country)
        {
            _context.Update(country);//editar dato a la base de  _context es la base de datos
            await _context.SaveChangesAsync(); //grabamos los datos realmente
            return Ok(country); //respuesta del guardado 200 si se guardo bien
        }

        //metodo para eliminar un dato 
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
