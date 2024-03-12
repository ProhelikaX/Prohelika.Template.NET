namespace Prohelika.Domain.Entities;

public class Message: AuditableEntity<Guid, Person>
{
    public string Content { get; set; }
}