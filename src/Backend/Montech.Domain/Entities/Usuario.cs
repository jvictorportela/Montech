namespace Montech.Domain.Entities;

public class Usuario : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string CpfOrCnpj { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public Guid UserIdentifier { get; set; } 

    // Relação
    //public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
