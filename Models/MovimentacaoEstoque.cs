public enum TipoMovimentacao { Entrada, Saida, Ajuste }

public class MovimentacaoEstoque
{
    public int Id { get; set; }
    public TipoMovimentacao Tipo { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataMovimentacao { get; set; } = DateTime.UtcNow;
    public string? Observacao { get; set; }

    public int ItemId { get; set; }
    public Item? Item { get; set; }
}