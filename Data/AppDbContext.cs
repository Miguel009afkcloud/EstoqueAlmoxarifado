public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Item> Itens { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<MovimentacaoEstoque> MovimentacoesEstoque { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .HasOne(i => i.Categoria)
            .WithMany(c => c.Itens)
            .HasForeignKey(i => i.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Item>()
            .HasOne(i => i.Fornecedor)
            .WithMany(f => f.Itens)
            .HasForeignKey(i => i.FornecedorId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<MovimentacaoEstoque>()
            .HasOne(m => m.Item)
            .WithMany(i => i.Movimentacoes)
            .HasForeignKey(m => m.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

            //Indices para performance
        modelBuilder.Entity<Item>()
            .HasIndex(i => i.CodigoBarras)
            .IsUnique();
            .HasFilter("[CodigoBarras] IS NOT NULL");
    }
}