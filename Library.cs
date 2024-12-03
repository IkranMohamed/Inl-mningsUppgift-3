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

            string attLäggaTillBokTitel = Console.ReadLine();  

            Console.Write("Hämta bok Id");

            string attLäggaTillBokId = Console.ReadLine();

            Console.Write("Hämta bokens författare");

            string attLäggaTillBokensFörfattare = Console.ReadLine();

            Console.Write("Året boken blev tillgänglig");

            int attLäggaTillÅret = int.Parse(Console.ReadLine());

            Console.Write("Lägg till bokens ISBN");

            string attLäggaTillISBN = Console.ReadLine();
            
            Console.Write("Lägg till bokens genre");

            string attLäggaTillGenre = Console.ReadLine();
           
            Book newBook = new Book(attLäggaTillBokId,attLäggaTillBokTitel,attLäggaTillBokensFörfattare, attLäggaTillISBN ,attLäggaTillGenre, attLäggaTillÅret);
            
            books.Add(newBook);
            Console.WriteLine("attLäggaTillBokensFörfattare");
        }  
    }
}

