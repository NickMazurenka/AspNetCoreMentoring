// TODO: Remove.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NorthwindTraders.Adapters.Driven.EntityFramework;

public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<NorthwindContext>
{
    public NorthwindContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<NorthwindContext>();

        var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True";

        builder.UseSqlServer(connectionString);

        // Stop client query evaluation
        builder.ConfigureWarnings(w =>
            w.Throw(RelationalEventId.QueryClientEvaluationWarning));

        return new NorthwindContext(builder.Options);
    }
}