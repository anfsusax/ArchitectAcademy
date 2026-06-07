using ArchitectAcademy.Domain.Common;

namespace ArchitectAcademy.Domain.Entities;

public class Aluno : Entity
{
    public string Nome { get; private set; }

    public string Email { get; private set; }

    public int XpTotal { get; private set; }

    public int Nivel { get; private set; }

    private Aluno()
    {
    }

    public Aluno(
        string nome,
        string email)
    {
        Nome = nome;
        Email = email;

        Nivel = 1;
        XpTotal = 0;
    }

    public void AdicionarXp(int xp)
    {
        XpTotal += xp;

        Nivel = XpTotal switch
        {
            >= 7500 => 5,
            >= 5000 => 4,
            >= 2500 => 3,
            >= 1000 => 2,
            _ => 1
        };
    }
}