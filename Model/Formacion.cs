using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formulario.Model;

public class Formacion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Jugador1 { get; set; }
    public string? Jugador2 { get; set; }
    public string? Jugador3 { get; set; }
    public string? Jugador4 { get; set; }
    public string? Jugador5 { get; set; }
    public string? Jugador6 { get; set; }
    public string? Jugador7 { get; set; }
    public string? Jugador8 { get; set; }
    public string? Jugador9 { get; set; }
    public string? Jugador10 { get; set; }
    public string? Jugador11 { get; set; }

}