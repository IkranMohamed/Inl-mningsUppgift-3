using System.Text.Json.Serialization;

namespace InlämningsUppgift_3
{
    public class DB
    {
        [JsonPropertyName("Books")]
        public List<Book> AllaBöckerFrånLista { get; set; }

        [JsonPropertyName("Författare")]
        public List<Författare> AllaBöckersFrånFörfattareLista { get; set; }
    }
}
