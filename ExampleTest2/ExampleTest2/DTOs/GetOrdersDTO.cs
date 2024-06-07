namespace ExampleTest2.DTOs;

public class GetOrdersDTO
{
    public int Id { get; set; }
    public DateTime AcceptedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    public string? Comments { get; set; }
    public ICollection<GetOrdersPastryDTO> Pastries { get; set; } = null!;
}

public class GetOrdersPastryDTO
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Amount { get; set; }
}