using ArchitectAcademy.Domain.Common;
using ArchitectAcademy.Domain.Enums;

namespace ArchitectAcademy.Domain.Entities;

public class Aula : Entity
{
    public string Titulo { get; private set; }

    public string Conteudo { get; private set; }

    public int DuracaoMinutos { get; private set; }

    public Guid DisciplinaId { get; private set; }

    public Disciplina Disciplina { get; private set; }

    public StatusAula Status { get; private set; }

    private Aula()
    {
    }

    public Aula(
        string titulo,
        string conteudo,
        int duracaoMinutos,
        Guid disciplinaId)
    {
        Titulo = titulo;
        Conteudo = conteudo;
        DuracaoMinutos = duracaoMinutos;
        DisciplinaId = disciplinaId;

        Status = StatusAula.NaoIniciada;
    }

    public void Iniciar()
    {
        Status = StatusAula.EmAndamento;
    }

    public void Concluir()
    {
        Status = StatusAula.Concluida;
    }
}