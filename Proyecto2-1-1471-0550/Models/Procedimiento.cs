namespace Proyecto1_1_1471_0550.Models
{
    public enum TipoProcedimiento
    {
        Consulta = 15000,
        ConsultaEspecial = 17000,
        Castracion_0_5kg = 35000,
        Castracion_5_10kg = 45000,
        Castracion_10_20kg = 55000,
        Castracion_20_30kg = 80000,
        Castracion_30_50kg = 100000,
        CirugiaMenor = 15000,
        CirugiaMayor = 25000,
        Grooming_Pequeño = 15000,
        Grooming_Mediano = 20000,
        Grooming_Grande = 25000,
        Grooming_ExtraGrande = 35000,
        VacunasAnuales = 40000
    }

    public enum EstadoProcedimiento
    {
        EnProceso,
        Facturado,
        Agendado
    }

    public class Procedimiento
    {
        public int Id { get; set; }
        public required string CedulaDueno { get; set; }
        public required string NombreMascota { get; set; }
        public required TipoProcedimiento TipoConsulta { get; set; }
        public EstadoProcedimiento Estado { get; set; } = EstadoProcedimiento.EnProceso;

        // ✅ Precio automático a partir del tipo de procedimiento
        public decimal Precio => (decimal)TipoConsulta;

        // ✅ Calcular total con IVA
        public decimal CalcularTotal()
        {
            const decimal IVA = 0.13m;
            return Precio + (Precio * IVA);
        }
    }
}