using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoderAPIEjemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        public AlumnosController()
        {

        }

        [HttpGet]
        public ActionResult ObtenerAlumnos()
        {
            return Ok(true);
        }
    }
}
