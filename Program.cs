using System.ComponentModel;
using System.Text.Json;

namespace InlämningsUppgift_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           string dataJSONfilPath = Path.Combine(Directory.GetCurrentDirectory(), "LibraryData.json");

            try
            {
                string allaTypeAvJson = File.ReadAllText(dataJSONfilPath);
                DB db = JsonSerializer.Deserialize<DB>(allaTypeAvJson)!;
                List<Book> allaBöcker = db.AllaBöckerFrånLista;
                List<Författare> allaförfattare = db.AllaBöckersFrånFörfattareLista;

                Console.WriteLine("Deserialisering lyckades!");
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON-parsefel: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod: {ex.Message}");
            }

            //string dataJSONfilPath = "LibraryData.json";
            //string allaTypeAvJsonPath = File.ReadAllText(dataJSONfilPath);
            //List<Book> books = new List<Book>();
            // List<Book> allaBöcker = författare.AllaBöckerFrånLista;
            //Författare författare = JsonSerializer.Deserialize<Författare>(allaTypeAvJsonPath)!;
            //string uppdateraBook = JsonSerializer.Serialize(allaBöcker, new JsonSerializerOptions { WriteIndented = true });

            //List<Book> allaBöckerMedTitel = allaBöcker.Where(Book => Book.Publiserinsår == 1988).ToList();

            //List<Book> allaBöckerMedBetygÖver4iordning = allaBöckerMedTitel.OrderByDescending(Book => Book.Publiserinsår).ToList();

            // allaBöckerMedBetygÖver4iordning.ForEach(Book => { Console.WriteLine(Book.Publiserinsår); });
            // allaBöcker.Add(new Book("1","IkkysBook", "Princess", "Fantasy", 1988, "111"));

            //string uppdateraBook = JsonSerializer.Serialize(allaBöcker, new JsonSerializerOptions { WriteIndented = true });
            //File.WriteAllText(dataJSONfilPath, uppdateraBook);
        }
    }
}
