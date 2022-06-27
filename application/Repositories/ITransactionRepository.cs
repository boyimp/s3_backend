// In the name of Allah


using Application.DBO;
using Application.Models;

namespace Application.Repositories;

public interface ITransactionRepository
{
    Task<List<Transaction>> GetTransactions(Data context);
    Task<List<Transaction>?> AddTransaction(List<ProductDTO> ProductDTOs,UserDTO userDTO, Data context);
}//interface