namespace Montech.Domain.Entities;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public bool Ativo { get; set; } = true;
}
