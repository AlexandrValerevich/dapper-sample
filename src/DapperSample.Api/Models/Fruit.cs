using Dapper.Contrib.Extensions;

namespace DapperSample.Api.Models;

[Table("public.\"Fruits\"")]
public class Fruit
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Count { get; set; }
}
