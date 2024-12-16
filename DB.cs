using System.Text.Json.Serialization;

namespace InlämningsUppgift_3
{
    public class DB
    {
        [JsonPropertyName("Books")]
        public List<Book> AllaBöckerFrånLista { get; set; } = new List<Book>();

        [JsonPropertyName("Författare")]
        public List<Författare> AllaBöckersFrånFörfattareLista { get; set; } = new List<Författare>();
    }

}
