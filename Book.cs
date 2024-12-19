namespace BookAuthor;
internal class Book
{
    private string[] acceptedLanguages = { "angol", "német", "magyar" };

    private long isbn;
    private List<Author> authors = [];
    private string title;
    private int year;
    private string language;
    private int stock;
    private int price;

    public long ISBN
    {
        get => isbn;
        private set
        {
            if (value.ToString().Trim().Length != 10)
                throw new ArgumentException("Az ISBN 10 számjegyből áll");
            isbn = value;
        }
    }
    public List<Author> Authors
    {
        get => authors;
        private set
        {
            if (value.Count < 1 || value.Count > 3)
                throw new ArgumentException("Egy könyvnek 1-3 szerzője lehet");
            authors = value;
        }
    }
    public string Title
    {
        get => title;
        private set
        {
            if (value.Length < 3 || value.Length > 64)
                throw new ArgumentException("A cím hossza 3-64 karakter lehet");
            title = value;
        }
    }
    public int Year
    {
        get => year;
        private set
        {
            if (value < 2007)
                throw new ArgumentException("Köztes érték: 2007 - jelen");
            year = value;
        }
    }
    public string Language
    {
        get => language;
        private set
        {
            if (!acceptedLanguages.Contains(value.ToLower()))
                throw new ArgumentException("A könyv nyelve angol, német vagy magyar lehet");
            language = value;
        }
    }
    public int Stock
    {
        get => stock;
        set
        {
            if (value < 0)
                throw new ArgumentException("A készlet nem lehet negatív");
            stock = value;
        }
    }
    public int Price
    {
        get => price;
        private set
        {
            if (value < 1000 || value > 10000 || value % 100 != 0)
                throw new ArgumentException("Az ár 1000 és 10000 közötti, kerek 100as szám");
            price = value;
        }
    }

    public Book(long isbn, List<string> authors, string title, int year, string language, int stock, int price)
    {
        ISBN = isbn;
        Authors = authors.Select(x => new Author(x)).ToList();
        Title = title;
        Year = year;
        Language = language;
        Stock = stock;
        Price = price;
    }

    public Book(string author, string title)
    {
        Stock = 0;
        Language = "magyar";
        Price = 4500;
        ISBN = new Random().Next(1000000000, 2000000000);
        Year = 2024;

        Authors.Add(new Author(author));
        Title = title;
    }

    public override string ToString()
    {
        return 
            $"{(Authors.Count > 1 ? "Szerzők:" : "Szerző:")} {string.Join(", ", Authors.Select(x => $"{x.FirstName} {x.LastName}"))}\n" +
            $"Cím: {Title}\n" +
            $"Kiadási év: {Year}\n" +
            $"Nyelv: {Language}\n" +
            $"Készlet: {(Stock > 0 ? $"{Stock} db" : "beszerzés alatt")}\n" +
            $"Ár: {Price} Ft\n";
    }

}