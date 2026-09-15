public class CriarItemDto
{
[Required, StringLength(100, MinimumLength = 3)]
public string Nome { get; set; } = string.Empty;
[StringLength(500)]
public string? Descricao { get; set; }
[StringLength(50)]
public string? CodigoBarras { get; set; }
[StringLength(10)]
public string? UnidadeMedida { get; set; } = "UN";
[Range(0, int.MaxValue)]
public int QuantidadeEstoque { get; set; }
[Range(0, int.MaxValue)]
public int QuantidadeMinima { get; set; }
[Range(0.01, double.MaxValue)]
public decimal PrecoUnitario { get; set; }
public DateTime? DataValidade { get; set; }
[Required]
public int CategoriaId { get; set; }
public int? FornecedorId { get; set; }
}