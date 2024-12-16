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

        private void SaveData()
        {
            string json = JsonSerializer.Serialize(new DB { AllaBöckerFrånLista = books, AllaBöckersFrånFörfattareLista = författare }, new JsonSerializerOptions { WriteIndented = true });
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "LibraryData.json");
            File.WriteAllText(filePath, json);
            Console.WriteLine("Data har sparats!");
        }

    }
}

