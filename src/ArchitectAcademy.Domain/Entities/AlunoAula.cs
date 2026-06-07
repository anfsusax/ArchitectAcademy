using ArchitectAcademy.Domain.Common;

public class AlunoAula : Entity
{
    public Guid AlunoId { get; private set; }

    public Guid AulaId { get; private set; }

    public bool Concluida { get; private set; }

    public DateTime? DataConclusao { get; private set; }
}