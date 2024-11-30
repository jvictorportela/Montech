using Montech.Domain.Enums;

namespace Montech.Communication.Requests.Produto;

public class RequestCreatedProductJson
{
    public string Nome { get; set; } = string.Empty;
    public CategoriaEnum Categoria { get; set; }
    public decimal ValorCompra { get; set; }
    public decimal? ValorMercado { get; set; }
    public decimal? ValorVenda { get; set; }

    //Relação
    public Domain.Entities.Usuario? Usuario { get; set; }
    public long UsuarioId { get; set; }
}
