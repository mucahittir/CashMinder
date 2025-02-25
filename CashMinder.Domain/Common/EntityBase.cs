namespace CashMinder.Domain.Common
{
    public class EntityBase : IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime UpdatedAt { get; set; } = new DateTime();
        public bool IsDeleted { get; set; } = false;
    }
}
