namespace Proyecto1_1_1471_0550.Models
{
    public enum PreferenciaContacto
    { 
       Llamada,
        Mensaje,
        Whatsapp
    }
public class Cliente
 {
    public required string Identificacion { get; set; }
    public required string NombreCompleto { get; set; }
    public required string Provincia { get; set; }
    public required string Canton { get; set; }
    public required string Distrito { get; set; }
    public required string DireccionExacta { get; set; }
    public required string Telefono { get; set; }
    public PreferenciaContacto Preferencia { get; set; }

    // representación rápida de dirección
    public string DireccionCompleta()
    {
        return $"{Provincia}, {Canton}, {Distrito} - {DireccionExacta}";
    }
  }
}
