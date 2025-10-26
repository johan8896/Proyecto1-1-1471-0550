using Microsoft.AspNetCore.Mvc;
using Proyecto1_1_1471_0550.Models;
using System.Linq;
using System.Collections.Generic;

namespace Proyecto2_1_1471_0550.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    

        public class EmpleadosController : ControllerBase
        {
            // Lista estática (simula una base de datos temporal)
            private static List<Empleado> empleados = new List<Empleado>();

            // ✅ GET: api/empleados
            [HttpGet]
            public ActionResult<IEnumerable<Empleado>> Get()
            {
                return Ok(empleados);
            }

            // ✅ GET: api/empleados/{cedula}
            [HttpGet("{cedula}")]
            public ActionResult<Empleado> GetByCedula(string cedula)
            {
                var emp = empleados.FirstOrDefault(e => e.Cedula == cedula);
                if (emp == null)
                    return NotFound(new { message = $"Empleado con cédula {cedula} no encontrado." });

                return Ok(emp);
            }

            // ✅ POST: api/empleados
            [HttpPost]
            public ActionResult Post([FromBody] Empleado empleado)
            {
                if (empleados.Any(e => e.Cedula == empleado.Cedula))
                    return BadRequest(new { message = "Ya existe un empleado con esa cédula." });

                empleados.Add(empleado);
                return Ok(new { message = "Empleado registrado correctamente." });
            }

            // ✅ PUT: api/empleados/{cedula}
            [HttpPut("{cedula}")]
            public ActionResult Put(string cedula, [FromBody] Empleado empleado)
            {
                var emp = empleados.FirstOrDefault(e => e.Cedula == cedula);
                if (emp == null)
                    return NotFound(new { message = $"Empleado con cédula {cedula} no encontrado." });

                emp.Nombre = empleado.Nombre;
                emp.FechaNacimiento = empleado.FechaNacimiento;
                emp.FechaIngreso = empleado.FechaIngreso;
                emp.SalarioPorDia = empleado.SalarioPorDia;
                emp.FechaRetiro = empleado.FechaRetiro;
                emp.Tipo = empleado.Tipo;

                return Ok(new { message = "Empleado actualizado correctamente." });
            }

            // ✅ DELETE: api/empleados/{cedula}
            [HttpDelete("{cedula}")]
            public ActionResult Delete(string cedula)
            {
                var emp = empleados.FirstOrDefault(e => e.Cedula == cedula);
                if (emp == null)
                    return NotFound(new { message = $"Empleado con cédula {cedula} no encontrado." });

                empleados.Remove(emp);
                return Ok(new { message = "Empleado eliminado correctamente." });
            }
        }
    }
