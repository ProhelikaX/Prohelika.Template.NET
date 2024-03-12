using Microsoft.EntityFrameworkCore;
using Prohelika.Domain.Entities;

namespace Prohelika.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Message> Messages { get; set; }
}