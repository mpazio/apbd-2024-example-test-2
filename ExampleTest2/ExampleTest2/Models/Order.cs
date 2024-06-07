using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    public DateTime AcceptedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    public string? Comments { get; set; }

    public int ClientId { get; set; }
    public int EmployeeId { get; set; }

    [ForeignKey(nameof(ClientId))]
    public Client Client { get; set; } = null!;
    [ForeignKey(nameof(EmployeeId))]
    public Employee Employee { get; set; } = null!;
    
    public ICollection<OrderPastry> OrderPastries { get; set; } = new HashSet<OrderPastry>();
}