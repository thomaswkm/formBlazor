using Formulario.Model;
using HtmlAgilityPack;
using Formulario.Data;

namespace Formulario.Service
{
    public class JugadorService
    {
        public async Task<List<Jugador>> ObtenerJugadores(string url)        {
            List<Jugador> jugadores = new List<Jugador>();

            try
            {
                HtmlWeb web = new HtmlWeb();

                HtmlDocument doc = web.Load(url);

                var playerNodes = doc.DocumentNode.SelectNodes("//tr[@class='odd' or @class='even']");

                if (playerNodes != null)
                {
                    foreach (var playerNode in playerNodes)
                    {
                        var playerName = playerNode.SelectSingleNode(".//td[@class='hauptlink']/a")?.InnerText.Trim();
                        
                        if (playerName.Contains("&nbsp;"))
                        {
                            playerName = playerName.Split("&")[0];
                        }

                        var playerPosition = playerNode
                            .SelectSingleNode(
                                ".//td[contains(text(), 'Portero') or contains(text(), 'Defensa central') or contains(text(), 'Lateral izquierdo')" +
                                "or contains(text(), 'Lateral derecho') or contains(text(), 'Pivote') or contains(text(), 'Mediocentro')" +
                                "or contains(text(), 'Mediocentro ofensivo') or contains(text(), 'Extremo izquierdo') or contains(text(), 'Extremo derecho')" +
                                "or contains(text(), 'Delantero centro')]")?.InnerText
                            .Trim();
                        

                        var playerImage = playerNode.SelectSingleNode(".//img[contains(@class, 'bilderrahmen-fixed')]")
                            ?.Attributes["data-src"]?.Value;

                        Jugador jugador = new Jugador
                        {
                            Nombre = playerName,
                            Posicion = playerPosition,
                            UrlImagen = playerImage
                        };
                        jugadores.Add(jugador);
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron jugadores.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener jugadores: " + ex.Message);
            }

            return jugadores;
        }
    }
}