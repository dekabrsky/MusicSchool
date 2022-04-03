namespace MusicSchoolModel.Core.Domain.Abstractions;

public class Entity
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}