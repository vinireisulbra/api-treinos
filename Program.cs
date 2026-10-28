using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=treinos.db"));

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();


app.MapGet("/api/treinos", async (AppDbContext db) =>
{
    var treinos = await db.Treinos.ToListAsync();
    return Results.Ok(treinos);
});

app.MapGet("/api/treinos/{id}", async (int id, AppDbContext db) =>
{
    var treino = await db.Treinos.FindAsync(id);

    if (treino is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(treino);
});

app.MapPost("/api/treinos", async (TreinoEntradaDto dados, AppDbContext db) =>
{
    var treino = new Treino
    {
        Nome = dados.Nome,
        GrupoMuscular = dados.GrupoMuscular,
        Series = dados.Series,
        Repeticoes = dados.Repeticoes,
        Carga = dados.Carga
    };

    db.Treinos.Add(treino);
    await db.SaveChangesAsync();

    return Results.Created($"/api/treinos/{treino.Id}", treino);
});

app.MapPut("/api/treinos/{id}", async (int id, TreinoEntradaDto dados, AppDbContext db) =>
{
    var treino = await db.Treinos.FindAsync(id);

    if (treino is null)
    {
        return Results.NotFound();
    }

    treino.Nome = dados.Nome;
    treino.GrupoMuscular = dados.GrupoMuscular;
    treino.Series = dados.Series;
    treino.Repeticoes = dados.Repeticoes;
    treino.Carga = dados.Carga;

    await db.SaveChangesAsync();

    return Results.Ok(treino);
});

app.MapDelete("/api/treinos/{id}", async (int id, AppDbContext db) =>
{
    var treino = await db.Treinos.FindAsync(id);

    if (treino is null)
    {
        return Results.NotFound();
    }

    db.Treinos.Remove(treino);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();

record TreinoEntradaDto(string Nome, string GrupoMuscular, int Series, int Repeticoes, decimal Carga);