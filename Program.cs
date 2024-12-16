using System.ComponentModel;
using System.Text.Json;

namespace InlämningsUppgift_3
{
    internal class Program
    {
        private static object? db;

        static void Main(string[] args)
        {

            string dataJSONfilPath = Path.Combine(Directory.GetCurrentDirectory(), "LibraryData.json");

            try
            {
                string jsonContent = File.ReadAllText(dataJSONfilPath);
                DB db = JsonSerializer.Deserialize<DB>(jsonContent);
                if (db != null)
                {
                    List<Book> allBooks = db.AllaBöckerFrånLista;
                    List<Författare> allAuthors = db.AllaBöckersFrånFörfattareLista;
                    Console.WriteLine("Deserialisering lyckades!");
                }
                else
                {
                    Console.WriteLine("Fel vid deserialisering: DB är null");
                }
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON-parsefel: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod: {ex.Message}");
            }

            Library library = new Library();

            while (true)
            {
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1. Lägg till bok");
                Console.WriteLine("2. Lägg till betyg");
                Console.WriteLine("3. Avsluta");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.AddNewBook();
                        break;
                    case "2":
                        // Handle rating logic
                        break;
                    case "3":
                        Console.WriteLine("Programmet avslutas...");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

            }
        }
    }
}
