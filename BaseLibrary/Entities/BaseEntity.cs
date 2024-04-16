using System.Text.Json.Serialization;

namespace BaseLibrary.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // one to many
    [JsonIgnore]
    public List<Employee>? Employees { get; set; }
}