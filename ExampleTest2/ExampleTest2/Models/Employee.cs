using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(120)]
    public string LastName { get; set; } = string.Empty;
    
    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}