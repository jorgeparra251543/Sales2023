using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //meteodo para obtener datos
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }









    }
}
