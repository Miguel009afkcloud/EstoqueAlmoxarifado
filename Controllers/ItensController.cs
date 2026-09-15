using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

[ApiController]
[Route("api/[controller]")]
public class ItensController : ControllerBase
{
   private readonly AppDbContext _context;
   public ItensController(AppDbContext context)
    {
        _context = context;
    }
    // GET: api/Itens
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetItens(
    [FromQuery] int? categoriaId,
    [FromQuery] bool? estoqueBaixo,
    [FromQuery] string? busca)
    {
        var query = _context.Itens
        .Include(i => i.Categoria)
        .Include(i => i.Fornecedor)
        .AsQueryable();

        if (categoriaId.HasValue)
            query = query.Where(i => i.CategoriaId == categoriaId.Value);

        if (estoqueBaixo == true)
            query = query.Where(i => i.QuantidadeEstoque <= i.QuantidadeMinima);

        if (!string.IsNullOrWhiteSpace(busca) || i.CodigoBarras!.Contains(busca));

         var itens = await query
            .Select(i => new ItemDto
            {
                Id = i.Id,
                Nome = i.Nome,
                Descricao = i.Descricao,
                CodigoBarras = i.CodigoBarras,
                UnidadeMedida = i.UnidadeMedida,
                QuantidadeEstoque = i.QuantidadeMinima,
                PrecoUnitario = i.PrecoUnitario,
                DataCadastro = i.DataCadastro,
                DataValidade = i.DataValidade,
                CategoriaNome = i.Categoria!.Nome,
                FornecedorNome = i.Fornecedor!= null ? i.Fornecedor.Nome : null

            })
            .ToListAsync();

            return Ok(itens);

            // GET: api/itens/5
            [HttpGet("{id}")]
            public async Task<ActionResult<ItemDto>> GetItem(int id)
        {
            var item = await _context.Itens
            .Include(i => i.Categoria)
            .Include(i => i.Fornecedor)
            .FirstOrDefaultAsync(i => i.Id == id);

            if (item == null) return NotFound();

            return Ok(new ItemDto { /* mapeamento */ });

        }
        // POST: api/itens
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CriarItem(CriarItemDto dto)
        {
            var categoria = await _context.Categorias.FindAsync(dto.CategoriaId);
            if (categoria == null)
            return BadRequest("categoria não encontrada.");

            if (dto.FornecedorId.HasValue)
            {
                var fornecedor = await _context.Fornecedores.FindAsync(dto.FornecedorId.Value);
                if (fornecedor == null)
                    return BadRequest("Fornecedor não encontrado.");
            }
            var item = new Item
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                CodigoBarras = dto.CodigoBarras,
                UnidadeMedida = dto.UnidadeMedida,
                QuantidadeEstoque = dto.QuantidadeEstoque,
                QuantidadeMinima = dto.QuantidadeMinima,
                PrecoUnitario = dto.PrecoUnitario,
                DataValidade = dto.DataValidade,
                CategoriaId = dto.CategoriaId,
                FornecedorId = dto.FornecedorId
            };
            _context.Itens.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.Id}, item);
        }
        // PUT: api/itens/5
        [HttpPut("{id}")]
        public async Task <IActionResult> AtualizarItem(int id, CriarItemDto dto)
        {
            var item = await _context.Itens.FindAsync(id);
            if (item == null) return NotFound

        }
    }
}