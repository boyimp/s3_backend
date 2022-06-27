//In the name of Allah

using Application.Models;

namespace Application.DBO;

public class Data : DbContext
{
    public Data(DbContextOptions<Data> options) : base(options) { }//constructor

    public DbSet<User> Users => Set<User>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UserEntity().Configure(modelBuilder.Entity<User>());
        new ProductEntity().Configure(modelBuilder.Entity<Product>());
        new TransactionEntity().Configure(modelBuilder.Entity<Transaction>());

    }//func

}//class