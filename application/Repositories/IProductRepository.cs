// In the name of Allah

using Application.DBO;
using Application.Models;

namespace Application.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetProducts(Data context);
    Task<Product?> GetProductByName(string name,Data context);
    Task<Product?> AddProduct(ProductDTO productDTO,Data context);
    Task<Product?> UpdateProduct(string oldProductName,ProductDTO productDTO,Data context);
    Task<Product?> RemoveProduct(string productName,Data context);
}//interface