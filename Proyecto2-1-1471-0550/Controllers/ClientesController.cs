using Microsoft.AspNetCore.Mvc;
using Proyecto1_1_1471_0550.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto2_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private static List<Cliente> clientes = new List<Cliente>();

        // ✅ GET: api/clientes
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return Ok(clientes);
        }

        // ✅ GET: api/clientes/{identificacion}
        [HttpGet("{identificacion}")]
        public ActionResult<Cliente> GetById(string identificacion)
        {
            var cliente = clientes.FirstOrDefault(c => c.Identificacion == identificacion);
            if (cliente == null)
                return NotFound(new { message = "Cliente no encontrado" });

            return Ok(cliente);
        }

        // ✅ POST: api/clientes
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            if (clientes.Any(c => c.Identificacion == cliente.Identificacion))
                return BadRequest(new { message = "Ya existe un cliente con esa identificación." });

            clientes.Add(cliente);
            return Ok(new { message = "Cliente registrado correctamente" });
        }

        // ✅ PUT: api/clientes/{identificacion}
        [HttpPut("{identificacion}")]
        public ActionResult Put(string identificacion, [FromBody] Cliente cliente)
        {
            var existente = clientes.FirstOrDefault(c => c.Identificacion == identificacion);
            if (existente == null)
                return NotFound(new { message = "Cliente no encontrado" });

            existente.NombreCompleto = cliente.NombreCompleto;
            existente.Provincia = cliente.Provincia;
            existente.Canton = cliente.Canton;
            existente.Distrito = cliente.Distrito;
            existente.DireccionExacta = cliente.DireccionExacta;
            existente.Telefono = cliente.Telefono;
            existente.Preferencia = cliente.Preferencia;

            return Ok(new { message = "Cliente actualizado correctamente" });
        }

        // ✅ DELETE: api/clientes/{identificacion}
        [HttpDelete("{identificacion}")]
        public ActionResult Delete(string identificacion)
        {
            var cliente = clientes.FirstOrDefault(c => c.Identificacion == identificacion);
            if (cliente == null)
                return NotFound(new { message = "Cliente no encontrado" });

            clientes.Remove(cliente);
            return Ok(new { message = "Cliente eliminado correctamente" });
        }
    }
}
