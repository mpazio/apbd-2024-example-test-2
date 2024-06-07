using ExampleTest2.Data;
using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Order>> GetOrdersData(string? clientLastName)
    {
        return await _context.Orders
            .Include(e => e.Client)
            .Include(e => e.OrderPastries)
            .ThenInclude(e => e.Pastry)
            .Where(e => clientLastName == null || e.Client.LastName == clientLastName)
            .ToListAsync();
    }

    public async Task<bool> DoesClientExist(int clientID)
    {
        return await _context.Clients.AnyAsync(e => e.Id == clientID);
    }

    public async Task<bool> DoesEmployeeExist(int employeeID)
    {
        return await _context.Employees.AnyAsync(e => e.Id == employeeID);
    }

    public async Task AddNewOrder(Order order)
    {
        await _context.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<Pastry?> GetPastryByName(string name)
    {
        return await _context.Pastries.FirstOrDefaultAsync(e => e.Name == name);
    }

    public async Task AddOrderPastries(IEnumerable<OrderPastry> orderPastries)
    {
        await _context.AddRangeAsync(orderPastries);
        await _context.SaveChangesAsync();
    }
}