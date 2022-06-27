// In the name of Allah

using System.Text.Json;
using Application.DBO;
using Application.Models;
using Application.Repositories;
using Application.Utils;

namespace Application.Endpoints;

public class TransactionEndpoints : Endpoint
{
    public TransactionEndpoints(WebApplication application) : base(application){}//constructor

    public override void EndpointDefinition()
    {
        Application.MapGet(Routes.TRANSACTION_GET,GetTransactions);
        Application.MapPost(Routes.TRANSACTION_ADD,AddTransactions);
        
    }//func

    public static async Task<IResult> GetTransactions
    (
        ITransactionRepository repository, 
        Data context
        )
    {
        List<Transaction> transactions = await repository.GetTransactions(context);
        return Results.Ok(transactions);
    }//func

        public static async Task<IResult> AddTransactions
    (
        Dictionary<string,dynamic> transactionParameter,
        ITransactionRepository repository,
        Data context
        )
    {

        UserDTO userDTO = JsonSerializer.
                            Deserialize<UserDTO>(
                                transactionParameter[Strings.KEY_USER_DTO]
                                );

        List<ProductDTO> productDTOs = JsonSerializer
                                        .Deserialize<List<ProductDTO>>(
                                            transactionParameter[Strings.KEY_PRODUCT_DTO]
                                            );

        if(productDTOs.Count()==0) return Results.BadRequest();

        var transactions = await repository.AddTransaction(productDTOs,userDTO,context);
        return (transactions is null)
            ? Results.NotFound()
            : Results.Ok(transactions);
            
    }//func


}//class