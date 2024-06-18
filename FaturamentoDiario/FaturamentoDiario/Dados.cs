using System.Text.Json.Serialization;

namespace FaturamentoDiario
{
    public class Dados
    {
        [JsonPropertyName("dia")]
        public int Dia { get; set; }
        
        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }
    }
}
