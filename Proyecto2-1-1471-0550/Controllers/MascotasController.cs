using Microsoft.AspNetCore.Mvc;
using Proyecto1_1_1471_0550.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto2_1_1471_0550.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotasController : ControllerBase
    {
        // Lista simulada (base de datos en memoria)
        private static List<Mascota> mascotas = new List<Mascota>();

        // ✅ GET: api/mascotas
        [HttpGet]
        public ActionResult<IEnumerable<Mascota>> Get()
        {
            return Ok(mascotas);
        }

        // ✅ GET: api/mascotas/{id}
        [HttpGet("{id}")]
        public ActionResult<Mascota> GetById(int id)
        {
            var mascota = mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota == null)
                return NotFound(new { message = $"Mascota con ID {id} no encontrada." });

            return Ok(mascota);
        }

        // ✅ POST: api/mascotas
        [HttpPost]
        public ActionResult Post([FromBody] Mascota mascota)
        {
            // Asignar un Id incremental
            mascota.Id = mascotas.Count > 0 ? mascotas.Max(m => m.Id) + 1 : 1;
            mascotas.Add(mascota);

            return Ok(new { message = "Mascota registrada correctamente." });
        }

        // ✅ PUT: api/mascotas/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Mascota mascota)
        {
            var existente = mascotas.FirstOrDefault(m => m.Id == id);
            if (existente == null)
                return NotFound(new { message = $"Mascota con ID {id} no encontrada." });

            existente.CedulaDueno = mascota.CedulaDueno;
            existente.TipoEspecie = mascota.TipoEspecie;
            existente.Raza = mascota.Raza;
            existente.Edad = mascota.Edad;
            existente.Color = mascota.Color;
            existente.UltimaAtencion = mascota.UltimaAtencion;
            existente.TelefonoDueno = mascota.TelefonoDueno;
            existente.EmailDueno = mascota.EmailDueno;

            return Ok(new { message = "Mascota actualizada correctamente." });
        }

        // ✅ DELETE: api/mascotas/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var mascota = mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota == null)
                return NotFound(new { message = $"Mascota con ID {id} no encontrada." });

            mascotas.Remove(mascota);
            return Ok(new { message = "Mascota eliminada correctamente." });
        }
    }
}
