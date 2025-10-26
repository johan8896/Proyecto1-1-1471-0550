using Microsoft.AspNetCore.Mvc;
using Proyecto1_1_1471_0550.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto2_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcedimientosController : ControllerBase
    {
        private static List<Procedimiento> procedimientos = new List<Procedimiento>();

        // ✅ GET: api/procedimientos
        [HttpGet]
        public ActionResult<IEnumerable<Procedimiento>> Get()
        {
            return Ok(procedimientos);
        }

        // ✅ GET: api/procedimientos/{id}
        [HttpGet("{id}")]
        public ActionResult<Procedimiento> GetById(int id)
        {
            var p = procedimientos.FirstOrDefault(x => x.Id == id);
            if (p == null)
                return NotFound(new { message = "Procedimiento no encontrado." });

            return Ok(p);
        }

        // ✅ POST: api/procedimientos
        [HttpPost]
        public ActionResult Post([FromBody] Procedimiento procedimiento)
        {
            procedimiento.Id = procedimientos.Count > 0 ? procedimientos.Max(p => p.Id) + 1 : 1;
            procedimientos.Add(procedimiento);
            return Ok(new { message = "Procedimiento registrado correctamente." });
        }

        // ✅ PUT: api/procedimientos/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Procedimiento procedimiento)
        {
            var existente = procedimientos.FirstOrDefault(p => p.Id == id);
            if (existente == null)
                return NotFound(new { message = "Procedimiento no encontrado." });

            existente.CedulaDueno = procedimiento.CedulaDueno;
            existente.NombreMascota = procedimiento.NombreMascota;
            existente.TipoConsulta = procedimiento.TipoConsulta;
            existente.Estado = procedimiento.Estado;

            return Ok(new { message = "Procedimiento actualizado correctamente." });
        }

        // ✅ DELETE: api/procedimientos/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var procedimiento = procedimientos.FirstOrDefault(p => p.Id == id);
            if (procedimiento == null)
                return NotFound(new { message = "Procedimiento no encontrado." });

            procedimientos.Remove(procedimiento);
            return Ok(new { message = "Procedimiento eliminado correctamente." });
        }
    }
}
