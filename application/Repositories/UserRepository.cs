//In the name of Allah

using Application.DBO;
using Application.Models;

namespace Application.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<User?> AddUser(UserDTO userDTO, Data context)
    {
        User user = new User(id:Guid.NewGuid(),name:userDTO.name,password:userDTO.password);

        await context.Users.AddAsync(user);
        int result = await context.SaveChangesAsync();
        return (result > 0)?user:null;
    }//func

    public async Task<User?> GerUserByUser(UserDTO userDTO,Data context)
    {
        var user = await context.Users.FirstOrDefaultAsync<User>( 
            element => element.name.Equals(userDTO.name));
        return (user is null)?null:user;
    }//func
}//class