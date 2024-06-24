using GestorNotificaciones.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace GestorNotificaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class GestorMensajeriaController : ControllerBase
    {

        private readonly Utils _utils;

        public GestorMensajeriaController(Utils utils)
        {
            _utils = utils;
        }
        [HttpPost]
        public async Task<IActionResult> CrearEstudiante(EstudianteDTO infoEstudiante)
        {
            var bucket = _utils.GetBucket();
            var id = Guid.NewGuid().ToString();
            await bucket.DefaultCollection().InsertAsync(id, infoEstudiante);
            return Ok();
        }

    }

} 
