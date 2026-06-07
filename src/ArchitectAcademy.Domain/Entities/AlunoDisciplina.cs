using ArchitectAcademy.Domain.Common;

public class AlunoDisciplina : Entity
{
    public Guid AlunoId { get; private set; }

    public Guid DisciplinaId { get; private set; }

    public decimal Progresso { get; private set; }

    public decimal NotaFinal { get; private set; }

    public bool Concluida { get; private set; }

    public DateTime? DataConclusao { get; private set; }
}