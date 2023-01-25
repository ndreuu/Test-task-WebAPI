using Microsoft.EntityFrameworkCore;
using TestTaskSolution.Models;

namespace TestTaskSolution.Data;

public class APIDbContext : DbContext
{
    public APIDbContext(DbContextOptions options) : base(options)
    { }
    public DbSet<Value> Values { get; set; }
    public DbSet<Result> Result { get; set; }
}