using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

public class Pastry
{
    [Key]
    public int Id { get; set; }
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
    [DataType("decimal")]
    [Precision(10, 2)]
    public decimal Price { get; set; }
    [MaxLength(40)]
    public string Type { get; set; } = string.Empty;
    
    public ICollection<OrderPastry> OrderPastries { get; set; } = new HashSet<OrderPastry>();
}