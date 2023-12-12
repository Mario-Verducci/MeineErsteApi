using MeineErsteApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Alle Personen ausgeben
app.MapGet("/personen", () => Datenbank.Personen);

// Eine Person ausgeben
app.MapGet("/personen/{id}", (int id, ILogger<Program> logger) =>
{
    var person = Datenbank.Personen.FirstOrDefault(x => x.Id == id);

    if (person == null)
    {
        logger.LogError("Person mit falscher Id wurde aufgerufen. Id = {id}", id);
        return Results.NotFound();
    }

    return Results.Ok(person);
});

// Eine Person hinzufügen
app.MapPost("/personen", (Person person) =>
{
    int id = Datenbank.Personen.Max(x => x.Id) + 1;
    person.Id = id;
    Datenbank.Personen.Add(person);
    return Results.Created($"/personen/{person.Id}", person);
});

// Eine Person ändern
app.MapPut("/personen/{id}", (int id, Person person) =>
{
    if (id != person.Id)
    {
        return Results.BadRequest("Id in der Url und Id in der Person stimmen nicht überein");
    }

    var personInDb = Datenbank.Personen.FirstOrDefault(x => x.Id == id);

    if (personInDb == null)
    {
        return Results.NotFound();
    }

    personInDb.Vorname = person.Vorname;
    personInDb.Nachname = person.Nachname;
    personInDb.Alter = person.Alter;

    return Results.Ok(personInDb);
});

// Eine Person löschen
app.MapDelete("/personen/{id}", (int id) =>
{
    var person = Datenbank.Personen.FirstOrDefault(x => x.Id == id);

    if (person == null)
    {
        return Results.NotFound();
    }

    Datenbank.Personen.Remove(person);

    return Results.NoContent();
});

app.Run();