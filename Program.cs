var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Rota raiz - confirma que a API está no ar
app.MapGet("/", () => "API de Controle de Treinos está no ar!");

// Lista de treinos em memória, com dois registros iniciais
var treinos = new List<TreinoDto>
{
    new TreinoDto(1, "Treino A - Peito e Tríceps", "Peito", 4, 12, 20.0m),
    new TreinoDto(2, "Treino B - Costas e Bíceps", "Costas", 3, 10, 15.0m)
};

// GET /api/treinos - lista todos os treinos
app.MapGet("/api/treinos", () => Results.Ok(treinos));

// GET /api/treinos/{id} - busca um treino específico
app.MapGet("/api/treinos/{id}", (int id) =>
{
    var treino = treinos.FirstOrDefault(t => t.Id == id);

    if (treino is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(treino);
});

// POST /api/treinos - cria um novo treino
app.MapPost("/api/treinos", (TreinoEntradaDto dados) =>
{
    int proximoId = treinos.Count > 0 ? treinos.Max(t => t.Id) + 1 : 1;

    var novoTreino = new TreinoDto(
        proximoId,
        dados.Nome,
        dados.GrupoMuscular,
        dados.Series,
        dados.Repeticoes,
        dados.Carga
    );

    treinos.Add(novoTreino);

    return Results.Created($"/api/treinos/{novoTreino.Id}", novoTreino);
});

// PUT /api/treinos/{id} - atualiza um treino existente
app.MapPut("/api/treinos/{id}", (int id, TreinoEntradaDto dados) =>
{
    var index = treinos.FindIndex(t => t.Id == id);

    if (index == -1)
    {
        return Results.NotFound();
    }

    var treinoAtualizado = new TreinoDto(
        id,
        dados.Nome,
        dados.GrupoMuscular,
        dados.Series,
        dados.Repeticoes,
        dados.Carga
    );

    treinos[index] = treinoAtualizado;

    return Results.Ok(treinoAtualizado);
});

// DELETE /api/treinos/{id} - remove um treino
app.MapDelete("/api/treinos/{id}", (int id) =>
{
    var treino = treinos.FirstOrDefault(t => t.Id == id);

    if (treino is null)
    {
        return Results.NotFound();
    }

    treinos.Remove(treino);

    return Results.NoContent();
});

app.Run();

// DTOs - formato dos dados
record TreinoDto(int Id, string Nome, string GrupoMuscular, int Series, int Repeticoes, decimal Carga);
record TreinoEntradaDto(string Nome, string GrupoMuscular, int Series, int Repeticoes, decimal Carga);