// In the name of Allah

using Application.DBO;
using Application.Models;
using Application.Repositories;
using Application.Utils;

namespace Application.Endpoints;

public class UserEndpoints : Endpoint
{
    public UserEndpoints(WebApplication application) : base(application) { }//constructor

    public override void EndpointDefinition()
    {
        Application.MapPost(Routes.USER_VERIFY, IsVerifiedUser);
        Application.MapPost(Routes.USER_ADD, AddUser);

    }//func

    public static async Task<IResult> IsVerifiedUser(UserDTO userDTO, IUserRepository repository, Data context)
    {
        Console.WriteLine("I get it!");
        if (String.IsNullOrEmpty(userDTO.name)) return Results.NotFound("Name is null or empty!");
        if (String.IsNullOrEmpty(userDTO.password)) return Results.BadRequest("Password is null or empty!");

        var user = await repository.GerUserByUser(userDTO, context);

        if (user is not null)
        {
            return (user.password.Equals(userDTO.password))
             ? Results.Ok(user)
             : Results.BadRequest("Invalid Password!");
        }//if

        return Results.NotFound("User not found!");

    }//func
    
     public static async Task<IResult> AddUser
    (
        UserDTO userDTO,
        IUserRepository repository,
        Data context
        )
    {
        var product = await repository.AddUser(userDTO,context);
        return (product is null)
            ? Results.NotFound()
            : Results.Ok(product);
    }//func


}//class