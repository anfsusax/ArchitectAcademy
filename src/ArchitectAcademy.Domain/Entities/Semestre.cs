using ArchitectAcademy.Domain.Common;

namespace ArchitectAcademy.Domain.Entities;

public class Semestre : Entity
{
    public string Nome { get; private set; }

    public int Ordem { get; private set; }

    public ICollection<Disciplina> Disciplinas { get; private set; }
        = new List<Disciplina>();

    private Semestre()
    {
    }

    public Semestre(string nome, int ordem)
    {
        Nome = nome;
        Ordem = ordem;
    }
}