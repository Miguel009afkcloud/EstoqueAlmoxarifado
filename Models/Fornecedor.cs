public class Fornecedor
{
public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Cnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public ICollection<Item> Itens { get; set; } = new List<Item>();
}