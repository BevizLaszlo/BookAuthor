

using BookAuthor;

Random rnd = new Random();
List<Book> books = [];

string[] authors =
{
    "William Shakespeare",
    "Jane Austen",
    "George Orwell",
    "Ernest Hemingway",
    "J.K. Rowling",
    "Toni Morrison",
    "Mark Twain",
    "Charles Dickens",
    "Virginia Woolf",
    "Gabriel Márquez",
    "Haruki Murakami",
    "Agatha Christie",
    "Fyodor Dostoevsky",
    "Leo Tolstoy",
    "J.R.R. Tolkien",
    "James Joyce",
    "Emily Dickinson",
    "Oscar Wilde",
    "Homer Simpson",
    "Franz Kafka",
    "Maya Angelou",
    "Margaret Atwood",
    "Stephen King",
    "Chinua Achebe",
    "Arthur Doyle"
};

string[] titles =
{
    "The Midnight Library",
    "Shadows of Eternity",
    "The Silent Patient",
    "Winds of Chaos",
    "The Alchemist's Secret",
    "Echoes of the Past",
    "Beneath a Scarlet Sky",
    "The Forgotten Kingdom",
    "The Glass Castle",
    "The Maze of Shadows",
    "The Lighthouse Keeper",
    "Whispers in the Dark",
    "The Paper Palace",
    "A Song for the Broken",
    "Lost Among Stars",
    "The Final Chapter",
    "The Crescent Moon",
    "Dreams of Tomorrow",
    "The Edge of Forever",
    "The Hidden City",
    "Secrets of the Ocean",
    "The Fire Within",
    "The Winter Garden",
    "The Traveler's Tale",
    "Beyond the Horizon"
};

int GenerateISBN()
{
    return rnd.Next(1000000000, 2000000000);
}

//feltöltés

for (int i = 0; i < 15; i++)
{
    int isbn;
    do
    {
        isbn = GenerateISBN();
    } while (books.Any(x => x.ISBN == isbn));
    string lang = rnd.Next(0, 10) < 8 ? "magyar" : "angol";

    bool hasOneAuthor = rnd.Next(0, 10) < 8;

    List<string> selectedAuthors = [];

    if (hasOneAuthor)
        selectedAuthors.Add(authors[rnd.Next(0, authors.Length)]);
    else
    {
        int authorCount = rnd.Next(2, 3);
        for (int j = 0; j < authorCount; j++)
        {
            string author;
            do
            {
                author = authors[rnd.Next(0, authors.Length)];
            } while (selectedAuthors.Contains(author));
            selectedAuthors.Add(author);
        }
    }

    string title = titles[rnd.Next(0, titles.Length)];
    int year = rnd.Next(2007, 2023);

    bool isInStock = rnd.Next(0, 10) < 8;
    int stock = isInStock ? rnd.Next(2, 3) : 0;

    books.Add(new Book(isbn, selectedAuthors, title, year, lang, stock, rnd.Next(1, 10) * 1000));
}

foreach (var book in books)
    Console.WriteLine(book.ToString());

// emuláció

int income = 0;
int bookCount = books.Sum(x => x.Stock);
int newBooks = 0;

for (int i = 0; i < 100; i++)
{
    if (books.Count == 0)
        break;

    Book book = books[rnd.Next(0, books.Count)];
    if (book.Stock > 0)
    {
        book.Stock--;
        income += book.Price;
    }
    else
    {
        bool canWeBuy = rnd.Next(1,2) == 1;
        if (canWeBuy)
        {
            int numOfBooks = rnd.Next(1, 10);

            book.Stock += numOfBooks;
            newBooks += numOfBooks;
        }
        else
            books.Remove(book);
    }
}

Console.WriteLine($"A bevétel: {income} Ft, {newBooks} könyvet szereztünk be, könyvek számának változása: {bookCount} -> {books.Sum(x => x.Stock)}.");