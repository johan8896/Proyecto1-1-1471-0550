namespace Proyecto1_1_1471_0550.Models
{
    public enum Especie
    {
        Caballo, Perro, Gato, Pez, Cabra, Conejo,
        Vaca, Cerdo, Roedor, Serpiente, Otro
    }
    public class Mascota
    {
        public int Id { get; set; }

        public required string CedulaDueno { get; set; }
        public Especie TipoEspecie { get; set; }
        public required string Raza { get; set; }
        public int Edad { get; set; }
        public required string Color { get; set; }
        public DateTime UltimaAtencion { get; set; }
        public  required string TelefonoDueno { get; set; }
        public required string EmailDueno { get; set; }

        // verificar si la mascota necesita atención anual
        public bool NecesitaVacunaAnual()
        {
            return (DateTime.Now - UltimaAtencion).TotalDays > 365;
        }
    }
}
