namespace ArchitectAcademy.Domain.Common
{
    /// <summary>
    /// Classe base para todas as entidades.
    /// Fornece funcionalidades comuns como Id e timestamps.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Identificador único da entidade
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data e hora da criação
        /// </summary>
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Data e hora da última atualização
        /// </summary>
        public DateTime? DataAtualizacao { get; set; }

        /// <summary>
        /// Se a entidade foi deletada logicamente
        /// </summary>
        public bool Deletado { get; set; }

        protected BaseEntity()
        {
            DataCriacao = DateTime.UtcNow;
            Deletado = false;
        }
    }

    /// <summary>
    /// Classe base para agregados.
    /// Agregados são grupos de entidades tratados como uma unidade.
    /// </summary>
    public abstract class AggregateRoot : BaseEntity
    {
        private readonly List<DomainEvent> _domainEvents = new();

        public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(DomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }

    /// <summary>
    /// Classe base para eventos de domínio.
    /// Eventos representam algo importante que aconteceu no domínio.
    /// </summary>
    public abstract class DomainEvent
    {
        public DateTime OcorridoEm { get; protected set; }
        public Guid IdEvento { get; protected set; }

        protected DomainEvent()
        {
            IdEvento = Guid.NewGuid();
            OcorridoEm = DateTime.UtcNow;
        }
    }
}
