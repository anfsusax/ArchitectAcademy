namespace ArchitectAcademy.Domain.ValueObjects
{
    /// <summary>
    /// Value Object para representar uma nota/pontuação
    /// </summary>
    public class Nota : IEquatable<Nota>, IComparable<Nota>
    {
        public const decimal NOTA_MINIMA = 0m;
        public const decimal NOTA_MAXIMA = 100m;
        public const decimal NOTA_MINIMA_APROVACAO = 70m;

        public decimal Valor { get; private set; }

        private Nota(decimal valor)
        {
            Valor = valor;
        }

        public static Nota Criar(decimal valor)
        {
            if (valor < NOTA_MINIMA || valor > NOTA_MAXIMA)
                throw new ArgumentException(
                    $"Nota deve estar entre {NOTA_MINIMA} e {NOTA_MAXIMA}. Recebido: {valor}");

            return new Nota(valor);
        }

        public bool EstaAprovado => Valor >= NOTA_MINIMA_APROVACAO;

        public decimal PontosFaltandoParaAprovacao =>
            EstaAprovado ? 0 : NOTA_MINIMA_APROVACAO - Valor;

        public string ObterLetra()
        {
            return Valor switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                _ => "F"
            };
        }

        public bool Equals(Nota other) =>
            other != null && Valor == other.Valor;

        public int CompareTo(Nota other) =>
            other == null ? 1 : Valor.CompareTo(other.Valor);

        public override bool Equals(object obj) =>
            Equals(obj as Nota);

        public override int GetHashCode() =>
            Valor.GetHashCode();

        public override string ToString() =>
            $"{Valor:F2}";

        public static bool operator ==(Nota left, Nota right) =>
            left?.Equals(right) ?? right == null;

        public static bool operator !=(Nota left, Nota right) =>
            !(left == right);
    }

    /// <summary>
    /// Value Object para XP (Experience Points)
    /// </summary>
    public class XP : IEquatable<XP>, IComparable<XP>
    {
        public const int XP_MINIMO = 0;
        public const int XP_MAXIMO = 999999;

        public int Valor { get; private set; }

        private XP(int valor)
        {
            Valor = valor;
        }

        public static XP Criar(int valor)
        {
            if (valor < XP_MINIMO || valor > XP_MAXIMO)
                throw new ArgumentException(
                    $"XP deve estar entre {XP_MINIMO} e {XP_MAXIMO}. Recebido: {valor}");

            return new XP(valor);
        }

        public int ObterNivel()
        {
            return Valor switch
            {
                < 1000 => 1,
                < 2500 => 2,
                < 5000 => 3,
                < 7500 => 4,
                _ => 5
            };
        }

        public string ObterNomNivel()
        {
            return ObterNivel() switch
            {
                1 => "🥉 Bronze",
                2 => "🥈 Prata",
                3 => "🥇 Ouro",
                4 => "💎 Diamante",
                5 => "👑 Mestre Arquiteto",
                _ => "Desconhecido"
            };
        }

        public int XpNecessarioParaProximoNivel()
        {
            var proximoNivel = ObterNivel() + 1;
            var xpProximoNivel = proximoNivel switch
            {
                2 => 1000,
                3 => 2500,
                4 => 5000,
                5 => 7500,
                _ => 999999
            };

            return xpProximoNivel - Valor;
        }

        public decimal ProgressoParaProximoNivel()
        {
            var nivel = ObterNivel();
            var xpAtualNivel = nivel switch
            {
                1 => 0,
                2 => 1000,
                3 => 2500,
                4 => 5000,
                5 => 7500,
                _ => 0
            };

            var xpProximoNivel = xpAtualNivel + XpNecessarioParaProximoNivel();
            var xpNoIntervalo = Valor - xpAtualNivel;
            var intervalo = xpProximoNivel - xpAtualNivel;

            return (decimal)xpNoIntervalo / intervalo * 100;
        }

        public bool Equals(XP other) =>
            other != null && Valor == other.Valor;

        public int CompareTo(XP other) =>
            other == null ? 1 : Valor.CompareTo(other.Valor);

        public override bool Equals(object obj) =>
            Equals(obj as XP);

        public override int GetHashCode() =>
            Valor.GetHashCode();

        public override string ToString() =>
            $"{Valor} XP";
    }

    /// <summary>
    /// Value Object para Duração (tempo em minutos)
    /// </summary>
    public class Duracao : IEquatable<Duracao>, IComparable<Duracao>
    {
        public const int MINIMO_MINUTOS = 5;
        public const int MAXIMO_MINUTOS = 480;

        public int Minutos { get; private set; }

        private Duracao(int minutos)
        {
            Minutos = minutos;
        }

        public static Duracao Criar(int minutos)
        {
            if (minutos < MINIMO_MINUTOS || minutos > MAXIMO_MINUTOS)
                throw new ArgumentException(
                    $"Duração deve estar entre {MINIMO_MINUTOS} e {MAXIMO_MINUTOS} minutos");

            return new Duracao(minutos);
        }

        public TimeSpan ObterTimeSpan() =>
            TimeSpan.FromMinutes(Minutos);

        public string ObterFormatado()
        {
            if (Minutos < 60)
                return $"{Minutos} minutos";

            var horas = Minutos / 60;
            var minutos = Minutos % 60;

            return minutos > 0
                ? $"{horas}h {minutos}m"
                : $"{horas}h";
        }

        public bool Equals(Duracao other) =>
            other != null && Minutos == other.Minutos;

        public int CompareTo(Duracao other) =>
            other == null ? 1 : Minutos.CompareTo(other.Minutos);

        public override bool Equals(object obj) =>
            Equals(obj as Duracao);

        public override int GetHashCode() =>
            Minutos.GetHashCode();

        public override string ToString() =>
            ObterFormatado();
    }

    /// <summary>
    /// Value Object para Dificuldade (1-5)
    /// </summary>
    public class Dificuldade : IEquatable<Dificuldade>, IComparable<Dificuldade>
    {
        public const int MINIMA = 1;
        public const int MAXIMA = 5;

        public int Nivel { get; private set; }

        private Dificuldade(int nivel)
        {
            Nivel = nivel;
        }

        public static Dificuldade Criar(int nivel)
        {
            if (nivel < MINIMA || nivel > MAXIMA)
                throw new ArgumentException(
                    $"Dificuldade deve estar entre {MINIMA} e {MAXIMA}");

            return new Dificuldade(nivel);
        }

        public string ObterEmoji()
        {
            return Nivel switch
            {
                1 => "😊 Fácil",
                2 => "😐 Médio",
                3 => "😠 Difícil",
                4 => "😡 Muito Difícil",
                5 => "🤯 Extremo",
                _ => "❓ Desconhecido"
            };
        }

        public bool Equals(Dificuldade other) =>
            other != null && Nivel == other.Nivel;

        public int CompareTo(Dificuldade other) =>
            other == null ? 1 : Nivel.CompareTo(other.Nivel);

        public override bool Equals(object obj) =>
            Equals(obj as Dificuldade);

        public override int GetHashCode() =>
            Nivel.GetHashCode();

        public override string ToString() =>
            ObterEmoji();
    }
}
