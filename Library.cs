using System.Text.Json;

namespace InlämningsUppgift_3
{
    public class Library
    {
        public List<Book> books {  get; set; } = new List<Book>();

        public List<Författare> författare { get; set; } = new List<Författare>();

        ///Lägga till en bok

        public void AddNewBook()
        {
            Console.WriteLine("Vänligen hämta bok information..");

            Console.WriteLine("Hämta bokens titel");
            string bookTitle = Console.ReadLine();

            Console.Write("Hämta bok Id");
            string bookId = Console.ReadLine();

            Console.Write("Hämta bokens författare");
            string authorName = Console.ReadLine();

            Console.Write("Året boken blev tillgänglig");
            int publishYear = int.Parse(Console.ReadLine());

            Console.Write("Lägg till bokens ISBN");
            string isbn = Console.ReadLine();

            Console.Write("Lägg till bokens genre");
            string genre = Console.ReadLine();

            Book newBook = new Book(bookId, bookTitle, authorName, isbn, genre, publishYear);
            books.Add(newBook);

            Console.WriteLine($"Boken '{bookTitle}' har lagts till!");

            // Save the updated data back to JSON
            SaveData();
        }

        // Lägg till betyg till en bok 

        public void AddRatingToBook()
        {
            Console.Write("Ange bok ID för att lägga till betyg: ");
            string bookId = Console.ReadLine();
            Book book = books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                book.AddRating();
            }
            else
            {
                Console.WriteLine("Bok med det angivna ID:t finns inte.");
            }
        }

        private void SaveData()
        {
            string json = JsonSerializer.Serialize(new DB { AllaBöckerFrånLista = books, AllaBöckersFrånFörfattareLista = författare }, new JsonSerializerOptions { WriteIndented = true });
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "LibraryData.json");
            File.WriteAllText(filePath, json);
            Console.WriteLine("Data har sparats!");
        }

        // Ladda data från JSON

        public void LoadData()
        {
            string dataJSONfilPath = Path.Combine(Directory.GetCurrentDirectory(), "LibraryData.json");

            try
            {
                string jsonContent = File.ReadAllText(dataJSONfilPath);
                DB db = JsonSerializer.Deserialize<DB>(jsonContent);
                if (db != null)
                {
                    books = db.AllaBöckerFrånLista;
                    författare = db.AllaBöckersFrånFörfattareLista;
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

            public void RemoveBook()
            {
                Console.Write("Ange bok ID för att ta bort: ");
                string bookId = Console.ReadLine();

                Book bookToRemove = books.FirstOrDefault(b => b.Id == bookId);

                if (bookToRemove != null)
                {
                    books.Remove(bookToRemove);
                    Console.WriteLine($"Boken med ID {bookId} har tagits bort.");
                    SaveData();
                }
                else
                {
                    Console.WriteLine("Ingen bok med det angivna ID:t hittades.");
                }
            }
            public void UpdateBook()
            {
                Console.Write("Ange bok ID för att uppdatera: ");
                string bookId = Console.ReadLine();

                Book bookToUpdate = books.FirstOrDefault(b => b.Id == bookId);

                if (bookToUpdate != null)
                {
                    Console.WriteLine("Vad vill du uppdatera?");
                    Console.WriteLine("1. Titel");
                    Console.WriteLine("2. Författare");
                    Console.WriteLine("3. Genre");
                    string updateChoice = Console.ReadLine();

                    switch (updateChoice)
                    {
                        case "1":
                            Console.Write("Ange ny titel: ");
                            bookToUpdate.Title = Console.ReadLine();
                            break;
                        case "2":
                            Console.Write("Ange ny författare: ");
                            bookToUpdate.Författare = Console.ReadLine();
                            break;
                        case "3":
                            Console.Write("Ange ny genre: ");
                            bookToUpdate.Genre = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val.");
                            break;
                    }
                    Console.WriteLine("Boken har uppdaterats!");
                    SaveData();  // Spara data efter uppdatering
                }
                else
                {
                    Console.WriteLine("Ingen bok med det angivna ID:t hittades.");
                }
            }


            // Filtrera böcker

            public List<Book> FilterBooks(string genre = null, string author = null, int? year = null)
            {
                var filteredBooks = books.AsQueryable();

                if (!string.IsNullOrEmpty(genre))
                    filteredBooks = filteredBooks.Where(b => b.Genre == genre);

                if (!string.IsNullOrEmpty(author))
                    filteredBooks = filteredBooks.Where(b => b.Författare == author);

                if (year.HasValue)
                    filteredBooks = filteredBooks.Where(b => b.Publiserinsår == year);

                return filteredBooks.ToList();

            }

            // Sortera böcker

            public List<Book> SortBooks(string sortBy)
            {
                switch (sortBy.ToLower())
                {
                    case "year":
                        return books.OrderBy(b => b.Publiserinsår).ToList();
                    case "title":
                        return books.OrderBy(b => b.Title).ToList();
                    case "author":
                        return books.OrderBy(b => b.Författare).ToList();
                    default:
                        return books;
                }
            }

            // Lista alla böcker
            public void ListBooks()
            {
                Console.WriteLine("Lista över alla böcker:");

                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Titel: {book.Title}, Författare: {book.Författare}, Publiceringsår: {book.Publiserinsår}, Genre: {book.Genre}, Genomsnittligt betyg: {book.GetAverageRating():F1}");
                }
            }

        }
    }
}

    


