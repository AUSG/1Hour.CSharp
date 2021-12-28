using C05_EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace C05_EntityFrameworkCore;

public class StudyDb : DbContext
{
    public StudyDb(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}