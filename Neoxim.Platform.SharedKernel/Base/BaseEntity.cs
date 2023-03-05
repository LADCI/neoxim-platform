namespace Neoxim.Platform.SharedKernel.Base;

/// <summary>
/// Base Entity
/// </summary>
public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTimeOffset CreationDate { get; protected set; }
    public DateTimeOffset LastChangesDate { get; protected set; }
}
