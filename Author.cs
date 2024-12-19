namespace BookAuthor;
internal class Author
{
    private string firstName;
    private string lastName;

    public Guid Guid { get; set; }
    public string FirstName
    {
        get => firstName;
        set
        {
            if (value.Length < 3 || value.Length > 32)
                throw new ArgumentException("A keresztnév hossza 3-32 karakter lehet");
            firstName = value;
        }
    }
    public string LastName
    {
        get => lastName;
        set
        {
            if (value.Length < 3 || value.Length > 32)
                throw new ArgumentException("A vezetéknév hossza 3-32 karakter lehet");
            lastName = value;
        }
    }

    public Author(string name)
    {
        Guid = Guid.NewGuid();
        string[] nameParts = name.Split(' ');
        FirstName = nameParts[0];
        LastName = nameParts[1];
    }
}
