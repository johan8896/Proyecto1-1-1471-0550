using Microsoft.AspNetCore.Mvc;
using Proyecto1_1_1471_0550.Models;

namespace Proyecto2_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MascotasController : ControllerBase
    {
        private static List<Mascota> mascotas = new();

        [HttpGet]
        public ActionResult<IEnumerable<Mascota>> Get() => Ok(mascotas);

        [HttpGet("{cedula}")]
        public ActionResult<Mascota> GetByCedula(string cedula)
        {
            var m = mascotas.FirstOrDefault(x => x.CedulaDueno == cedula);
            if (m == null) return NotFound();
            return Ok(m);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Mascota mascota)
        {
            mascotas.Add(mascota);
            return Ok(new { message = "Mascota registrada correctamente." });
        }

        [HttpPut("{cedula}")]
        public ActionResult Put(string cedula, [FromBody] Mascota mascota)
        {
            var existente = mascotas.FirstOrDefault(x => x.CedulaDueno == cedula);
            if (existente == null) return NotFound();

            existente.Raza = mascota.Raza;
            existente.Color = mascota.Color;
            existente.TelefonoDueno = mascota.TelefonoDueno;
            existente.EmailDueno = mascota.EmailDueno;
            existente.Edad = mascota.Edad;
            existente.TipoEspecie = mascota.TipoEspecie;
            existente.UltimaAtencion = mascota.UltimaAtencion;

            return Ok(new { message = "Mascota actualizada correctamente." });
        }

        [HttpDelete("{cedula}")]
        public ActionResult Delete(string cedula)
        {
            var mascota = mascotas.FirstOrDefault(x => x.CedulaDueno == cedula);
            if (mascota == null) return NotFound();

            mascotas.Remove(mascota);
            return Ok(new { message = "Mascota eliminada correctamente." });
        }
    }
}
