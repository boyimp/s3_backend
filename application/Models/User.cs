// In the name of Allah

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Models;

//Data Transfer Object
public record UserDTO(string name,string password);//record

//Model
public record User(Guid id,string name,string password);//record

//Entity
public class UserEntity : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
       builder.HasKey(user => user.name);
       builder.Property(user => user.id).ValueGeneratedOnAdd();
       builder.HasIndex(user => user.name);
       
    }//func
}//class