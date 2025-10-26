using Microsoft.AspNetCore.Mvc;

namespace Proyecto1_1_1471_0550.Models
{
    public enum TipoEmpleado
    {
        Veterinario,
        Asistente,
        Administrativo,
        Mantenimiento,
        Groomer
    }

    public class Empleado
    {
        public required string Cedula { get; set; }
        public required string Nombre { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required DateTime FechaIngreso { get; set; }
        public required decimal SalarioPorDia { get; set; }
        public required TipoEmpleado Tipo { get; set; }

        public DateTime? FechaRetiro { get; set; } // opcional

       
        public int AñosEnEmpresa()
        {
            var fin = FechaRetiro ?? DateTime.Now;
            return (int)((fin - FechaIngreso).TotalDays / 365);
        }

        public decimal SalarioMensual() => SalarioPorDia * 30;
    }
}
