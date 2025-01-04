using System.Text.Json.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace InlämningsUppgift_3
{
    public class Book
    {
        // Egenskaper för Book
        public string Id { get; set; }
        public string Title { get; set; }
        public string Författare { get; set; }
        public string Isbn { get; set; }
        public string Genre { get; set; }
        public int? Publiserinsår { get; set; }
        public List<int> Betyg { get; set; }

        // Constructor

        public Book() { }

        public Book(string id, string title, string författare, string isbn, string genre, int publiserinsår)
        {
            Id = id;
            Title = title;
            Författare = författare;
            Isbn = isbn;
            Genre = genre;
            Publiserinsår = publiserinsår;
            Betyg = new List<int>();
        }

        public void Addrating()
        {
            Console.WriteLine("Vänligen ange ett betyg mellan 1-5");
            int betygattläggatill;

            // Validering av inmatning
            while (!int.TryParse(Console.ReadLine(), out betygattläggatill) || betygattläggatill < 1 || betygattläggatill > 5)
            {
                Console.WriteLine("Ogiltigt betyg! Vänligen ange ett heltal mellan 1 och 5.");
            }

            // Lägg till betyget
            Betyg.Add(betygattläggatill);
            Console.WriteLine($"Betyget {betygattläggatill} har lagts till för boken '{Title}'!");

            // Calculating average rating
            double averageRating = Betyg.Average();
            Console.WriteLine($"Genomsnittligt betyg för '{Title}' är {averageRating:F1}");
        }

        public double GetAverageRating()
        {
            return Betyg.Any() ? Betyg.Average() : 0;
        }
    }
}
