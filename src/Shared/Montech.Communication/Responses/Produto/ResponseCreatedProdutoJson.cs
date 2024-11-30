using Montech.Domain.Enums;

namespace Montech.Communication.Responses.Produto;

public class ResponseCreatedProdutoJson
{
    public string Nome { get; set; } = string.Empty;
    public CategoriaEnum Categoria { get; set; }

    //Relação
    public Domain.Entities.Usuario? Usuario { get; set; }
    public long UsuarioId { get; set; }
}
