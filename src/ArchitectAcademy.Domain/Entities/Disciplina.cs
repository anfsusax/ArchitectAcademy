using ArchitectAcademy.Domain.Common;
using ArchitectAcademy.Domain.Enums;

namespace ArchitectAcademy.Domain.Entities;

public class Disciplina : Entity
{
    public string Nome { get; private set; }

    public string Descricao { get; private set; }

    public int Ordem { get; private set; }

    public Guid SemestreId { get; private set; }

    public Semestre Semestre { get; private set; }

    public StatusDisciplina Status { get; private set; }

    public ICollection<Aula> Aulas { get; private set; }
        = new List<Aula>();

    private Disciplina()
    {
    }

    public Disciplina(
        string nome,
        string descricao,
        int ordem,
        Guid semestreId)
    {
        Nome = nome;
        Descricao = descricao;
        Ordem = ordem;
        SemestreId = semestreId;

        Status = StatusDisciplina.Bloqueada;
    }

    public void Liberar()
    {
        Status = StatusDisciplina.Disponivel;
    }

    public void Iniciar()
    {
        Status = StatusDisciplina.EmAndamento;
    }

    public void Concluir()
    {
        Status = StatusDisciplina.Concluida;
    }
}