using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Treino> Treinos => Set<Treino>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Treino>().HasData(
            new Treino { Id = 1, Nome = "Treino A - Peito e Tríceps", GrupoMuscular = "Peito", Series = 4, Repeticoes = 12, Carga = 20.0m },
            new Treino { Id = 2, Nome = "Treino B - Costas e Bíceps", GrupoMuscular = "Costas", Series = 3, Repeticoes = 10, Carga = 15.0m }
        );
    }
}