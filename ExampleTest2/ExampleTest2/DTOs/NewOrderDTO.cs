using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.DTOs;

public class NewOrderDTO
{
    [Required]
    public int EmployeeID { get; set; }
    [Required]
    public DateTime AcceptedAt { get; set; }
    [MaxLength(300)]
    public string? Comments { get; set; } = null;
    [Required]
    public ICollection<NewOrderPastryDTO> Pastries { get; set; } = new List<NewOrderPastryDTO>();
}

public class NewOrderPastryDTO
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    [Range(1, int.MaxValue)]
    public int Amount { get; set; }
    [MaxLength(300)]
    public string? Comments { get; set; }
}