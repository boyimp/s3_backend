//In the name of Allah

using Application.DBO;
using Application.Models;

namespace Application.Repositories;

public class TransactionRepository : ITransactionRepository
{
    public async Task<List<Transaction>?> AddTransaction
    (
        List<ProductDTO> productDTOs, 
        UserDTO userDTO,
        Data context
        )
    {
        var transactionId = Guid.NewGuid();

        var user = await context.Users.FindAsync(userDTO.name);
        if( user is null) return null;

        List<Product> products = new List<Product>();
        List<Transaction> transactions = new List<Transaction>();

        foreach (ProductDTO productDTO in productDTOs)
        {
            var product = await context.Products.FindAsync(productDTO.name);
            if (product is not null)
            {
                products.Add(product);
            }//if
        }//for
        var transactionBuilder = await context.Database.BeginTransactionAsync();

        try
        {
            foreach (var product in products)
            {
                var transaction = new Transaction
                (
                    id: Guid.NewGuid(),
                    transactionId: transactionId,
                    productId: product.id,
                    userId: user.id,
                    transactionDateTime: DateTime.Now,
                    price: product.price
                );
                await context.Transactions.AddAsync(transaction);
                var result = await context.SaveChangesAsync();
                if(result > 0) transactions.Add(transaction);
            }//for

            await transactionBuilder.CommitAsync();

            return transactions;
        }//try
        catch (Exception)
        {
            return null;
        }
    }//func

    public async Task<List<Transaction>> GetTransactions(Data context)
    {
        var transactions = await context.Transactions.ToListAsync();
        return transactions;
    }//func

}//class