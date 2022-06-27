//In the name of Allah

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Models;


//Model
public record Transaction(
    Guid id,
    Guid transactionId,
    Guid productId,
    Guid userId,
    DateTime transactionDateTime,
    double price
    );//record

//Entity
public class TransactionEntity : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey( transaction => transaction.id);
        builder.Property( transaction => transaction.id).ValueGeneratedOnAdd();
        builder.HasIndex( transaction => transaction.transactionId);
    }//func
}//class