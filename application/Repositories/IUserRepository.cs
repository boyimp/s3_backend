//In the name of Allah

using Application.DBO;
using Application.Models;

namespace Application.Repositories;

public interface IUserRepository
{
    Task<User?> GerUserByUser(UserDTO user,Data context);
    Task<User?> AddUser(UserDTO userDTO,Data context);
}//interface