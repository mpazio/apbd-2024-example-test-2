using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Pastry> Pastries { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderPastry> OrderPastries { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Client>().HasData(new List<Client>
            {
                new Client {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski"
                },
                new Client {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Nowak"
                }
            });

            modelBuilder.Entity<Employee>().HasData(new List<Employee>
            {
                new Employee {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Nowak"
                },
                new Employee {
                    Id = 2,
                    FirstName = "Aleksandra",
                    LastName = "Wiśniewska"
                }
            });

            modelBuilder.Entity<Pastry>().HasData(new List<Pastry>
            {
                new Pastry
                {
                    Id = 1,
                    Name = "Drożdzówka",
                    Price = 3.3M,
                    Type = "A"
                },
                new Pastry
                {
                    Id = 2,
                    Name = "Babka cytrynowa",
                    Price = 21.23M,
                    Type = "B"
                },
                new Pastry
                {
                    Id = 3,
                    Name = "Jagodzianka",
                    Price = 7.2M,
                    Type = "A"
                }
            });

            modelBuilder.Entity<Order>().HasData(new List<Order>
            {
                new Order
                {
                    Id = 1,
                    AcceptedAt = DateTime.Parse("2024-05-28"),
                    FulfilledAt = DateTime.Parse("2024-05-29"),
                    Comments = "Lorem ipsum ...",
                    ClientId = 1,
                    EmployeeId = 2
                },
                new Order
                {
                    Id = 2,
                    AcceptedAt = DateTime.Parse("2024-05-31"),
                    FulfilledAt = DateTime.Parse("2024-06-01"),
                    Comments = "Lorem ipsum ...",
                    ClientId = 1,
                    EmployeeId = 1
                },
                new Order
                {
                    Id = 3,
                    AcceptedAt = DateTime.Parse("2024-06-01"),
                    FulfilledAt = null,
                    Comments = null,
                    ClientId = 2,
                    EmployeeId = 1
                }
            });

            modelBuilder.Entity<OrderPastry>().HasData(new List<OrderPastry>
            {
                new OrderPastry
                {
                    OrderId = 1,
                    PastryId = 1,
                    Amount = 3,
                },
                new OrderPastry
                {
                    OrderId = 1,
                    PastryId = 3,
                    Amount = 4,
                    Comment = "Lorem ipsum ..."
                },
                new OrderPastry
                {
                    OrderId = 2,
                    PastryId = 2,
                    Amount = 2
                },
                new OrderPastry
                {
                    OrderId = 2,
                    PastryId = 1,
                    Amount = 12
                }
            });
    }
}
