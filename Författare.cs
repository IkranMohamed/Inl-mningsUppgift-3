namespace InlämningsUppgift_3
{
    public class Författare
    {
        public string Id { get; set; }
        public string Namn { get; set; }
        public string Country { get; set; }

        public Författare() { } 
        public Författare(string id, string namn, string country) 
        {
            Id = id;
            Namn = namn;
            Country = country;

        }

    }
}
