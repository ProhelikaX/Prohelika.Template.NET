namespace Prohelika.Domain.Entities;

public abstract class Entity<TId>
{
    public TId Id { get; set; }
}

public abstract class AuditableEntity<TId, TUser> : Entity<TId>
{
    public DateTime CreatedAt { get; set; }
    public TUser? CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public TUser? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public TUser? DeletedBy { get; set; }

    public void MarkAsDeleted(TUser? user = default)
    {
        IsDeleted = true;
        DeletedAt = DateTime.Now;
        DeletedBy = user;
    }
}

