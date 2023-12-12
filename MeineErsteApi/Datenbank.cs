namespace MeineErsteApi;

public static class Datenbank
{
    public static List<Person> Personen = new List<Person>
    {
        new Person
        {
            Id = 1,
            Vorname = "Mario",
            Nachname = "Verducci",
            Alter = 36
        },
        new Person
        {
            Id = 2,
            Vorname = "Peter",
            Nachname = "Müller",
            Alter = 72
        },
        new Person
        {
            Id = 3,
            Vorname = "Peteraaaa",
            Nachname = "Müller",
            Alter = 72
        }
    };
}