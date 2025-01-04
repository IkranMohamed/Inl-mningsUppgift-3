using System.ComponentModel;
using System.Text.Json;

namespace InlämningsUppgift_3
{
    internal class Program
    {
        private static object? db;

        static void Main(string[] args)
        {
            Library library = new Library();
            library.LoadData(); // Ladda data från JSON-fil vid start

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



            while (true)
            {
                // Visa huvudmeny
                Console.Clear();
                Console.WriteLine("Välkommen till Bibliotekshanteraren!");
                Console.WriteLine("1. Lägg till ny bok");
                Console.WriteLine("2. Lägg till betyg till bok");
                Console.WriteLine("3. Spara data");
                Console.WriteLine("4. Ladda data");
                Console.WriteLine("5. Filtrera böcker");
                Console.WriteLine("6. Sortera böcker");
                Console.WriteLine("7. Lista alla böcker");
                Console.WriteLine("8. Ta bort bok");
                Console.WriteLine("9. Uppdatera bok");
                Console.WriteLine("0. Avsluta");
                Console.Write("Välj ett alternativ (0-9): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.AddNewBook();
                        break;
                    case "2":
                        library.AddRatingToBook();
                        break;
                    case "3":
                        library.SaveData();
                        break;
                    case "4":
                        library.LoadData();
                        break;
                    case "5":
                        // Filtrera böcker
                        Console.WriteLine("Filtrera böcker efter:");
                        Console.WriteLine("1. Genre");
                        Console.WriteLine("2. Författare");
                        Console.WriteLine("3. År");
                        string filterChoice = Console.ReadLine();

                        Console.WriteLine("Ange värde:");
                        string filterValue = Console.ReadLine();
                        if (filterChoice == "1")
                        {
                            var filteredBooks = library.FilterBooks(genre: filterValue);
                            ListBooks(filteredBooks);
                        }
                        else if (filterChoice == "2")
                        {
                            var filteredBooks = library.FilterBooks(author: filterValue);
                            ListBooks(filteredBooks);
                        }
                        else if (filterChoice == "3")
                        {
                            int year;
                            if (int.TryParse(filterValue, out year))
                            {
                                var filteredBooks = library.FilterBooks(year: year);
                                ListBooks(filteredBooks);
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt årtal.");
                            }
                        }
                    case "6":
                        // Sortera böcker
                        Console.WriteLine("Sortera böcker efter:");
                        Console.WriteLine("1. Titel");
                        Console.WriteLine("2. År");
                        Console.WriteLine("3. Författare");
                        string sortChoice = Console.ReadLine();

                        string sortBy = sortChoice switch
                        {
                            "1" => "title",
                            "2" => "year",
                            "3" => "author",
                            _ => ""
                        };

                        if (!string.IsNullOrEmpty(sortBy))
                        {
                            var sortedBooks = library.SortBooks(sortBy);
                            ListBooks(sortedBooks);
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt val.");
                        }
                        break;
                    case "7":
                        library.ListBooks();
                        break;
                    case "8":
                        library.RemoveBook();
                        break;
                    case "9":
                        library.UpdateBook();
                        break;
                    case "0":
                        Console.WriteLine("Tack för att du använde Bibliotekshanteraren!");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }

            if (choice != "0")
            {
                Console.WriteLine("Tryck på en tangent för att fortsätta...");
                Console.ReadKey();
            }

            static void ListBooks(List<Book> books)
            {
                Console.WriteLine("Lista över böcker:");

                if (books.Count == 0)
                {
                    Console.WriteLine("Inga böcker matchade.");
                }

                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Titel: {book.Title}, Författare: {book.Författare}, Publiceringsår: {book.Publiserinsår}, Genre: {book.Genre}, Genomsnittligt betyg: {book.GetAverageRating():F1}");
                }
            }
        }
    }
}