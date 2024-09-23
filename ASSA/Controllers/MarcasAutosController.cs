using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASSA.Data;
using ASSA.Models;

namespace ASSA.Controllers
{
    // Define la ruta del controlador como 'api/[controller]', lo que significa que el nombre del controlador 
    // (en este caso 'MarcasAutosController') determinará la ruta base de la API: 'api/marcasautos'.
    [Route("api/[controller]")]
    [ApiController] // Indica que este controlador es un controlador de API, lo que significa que maneja solicitudes HTTP y devuelve respuestas JSON.
    public class MarcasAutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        // El constructor recibe una instancia del contexto de base de datos 'AppDbContext' a través de inyección de dependencias.
        // Esto permite que el controlador interactúe con la base de datos para obtener datos.
        public MarcasAutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/marcasautos
        // Este método es un endpoint HTTP GET que devuelve todas las marcas de autos.
        // Usa Entity Framework para acceder a la tabla 'MarcasAutos' en la base de datos.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaAuto>>> GetMarcasAutos()
        {
            // Utilizamos el método 'ToListAsync' para obtener la lista de todas las marcas de autos de forma asíncrona.
            // La palabra clave 'await' asegura que el hilo no se bloquee mientras se espera el resultado de la consulta.
            // Esto es útil en aplicaciones web para mejorar la escalabilidad.
            return await _context.MarcasAutos.ToListAsync();
        }
    }
}
