//In the name of Allah

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Models;

//Data Transfer Object
public record ProductDTO(string name,double price);//record
//Model
public record Product
{
    public Guid id {get;set;}
    public string name {get;set;} = "";
    public double price {get;set;}
};//record

//Entity
public class ProductEntity : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey( product => product.name);
        builder.Property( product => product.id).ValueGeneratedOnAdd();
        builder.HasIndex( product => product.name);
    }//func
}//class