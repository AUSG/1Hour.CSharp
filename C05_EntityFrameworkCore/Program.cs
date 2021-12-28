// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using C05_EntityFrameworkCore;
using C05_EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

// 요것도 그냥 dotnet run 하세용.

var options = new DbContextOptionsBuilder<StudyDb>()
    .UseSqlite("Data Source=:memory:")
    .Options;

var db = new StudyDb(options);
db.Database.OpenConnection();
db.Database.EnsureCreated();

// Add new entity
await db.Customers.AddAsync(new Customer
{
    Id = 1,
    Memo = "hi",
    Name = "babo"
});
// Save new entity
await db.SaveChangesAsync();

// Get customers
var customers = await db.Customers.ToListAsync();


foreach (var customer in customers)
{
    Console.WriteLine(JsonSerializer.Serialize(customer));
}