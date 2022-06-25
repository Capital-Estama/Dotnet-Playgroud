using System;
namespace ChefsAndDishes.Models;

using Microsoft.EntityFrameworkCore;

// the MyContext class representing a session with our MySQL database, allowing us to query for or save data
public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    // the "-------" table name will come from the DbSet property name
    public DbSet<Chef> Chefs { get; set; }
    public DbSet<Dish> Dishes { get; set; }
}