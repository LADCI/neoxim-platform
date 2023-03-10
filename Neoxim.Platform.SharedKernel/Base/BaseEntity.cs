namespace Neoxim.Platform.SharedKernel.Base;

/// <summary>
/// Base Entity
/// </summary>
public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTimeOffset.UtcNow;
        LastChangesDate = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; protected set; }
    public DateTimeOffset CreationDate { get; protected set; }
    public DateTimeOffset LastChangesDate { get; protected set; }

    public void SetAsChanged()
    {
        LastChangesDate = DateTimeOffset.UtcNow;
    }
}
