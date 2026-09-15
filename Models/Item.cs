public class Item
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public string? CodigoBarras { get; set; }
    public string? UnidadeMedida { get; set; } = "UN";
    public int QuantidadeEstoque { get; set; }
    public int QuantidadeMinima { get; set; }
    public decimal PrecoUnitario { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    public DateTime? DataValidade { get; set; }

    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

    public int? FornecedorId { get; set; }
    public Fornecedor? Fornecedor { get; set; }

    public ICollection<MovimentacaoEstoque> Movimentacoes { get; set; } = new List<MovimentacaoEstoque>(); 
}