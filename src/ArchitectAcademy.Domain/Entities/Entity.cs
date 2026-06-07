namespace ArchitectAcademy.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();

    public DateTime DataCriacao { get; protected set; } = DateTime.UtcNow;

    public DateTime? DataAtualizacao { get; protected set; }

    public void Atualizar()
    {
        DataAtualizacao = DateTime.UtcNow;
    }
}