// In the name of Allah 

using Application.DBO;
using Application.Models;

namespace Application.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task<Product?> AddProduct(ProductDTO productDTO, Data context)
    {
        Product product = new Product
        {
            id = Guid.NewGuid(),
            name = productDTO.name,
            price = productDTO.price
        };

        await context.Products.AddAsync(product);
        int result = await context.SaveChangesAsync();
        return (result > 0)?product:null;
        
    }//func

    public async Task<Product?> GetProductByName(string name, Data context)
    {
       var product = await context.Products.FirstOrDefaultAsync(element => element.name.Equals(name));
       return (product is null)?null:product;
    }//func

    public async Task<List<Product>> GetProducts(Data context)
    {
        List<Product> products = new List<Product>();
        products = await context.Products.ToListAsync<Product>();
        return products;
    }//func

    public async Task<Product?> RemoveProduct(string productName, Data context)
    {
        var product = await context.Products.FindAsync(productName);
        if(product is null) return null;
        context.Products.Remove(product);
        var result = await context.SaveChangesAsync();
        return (result > 0)?product:null;
    }//func

    public async Task<Product?> UpdateProduct(string oldProductName, ProductDTO productDTO, Data context)
    {
        Product? oldProduct = await context.Products.FindAsync(oldProductName);
        if(oldProduct is null) return null;
        oldProduct.name = productDTO.name;
        oldProduct.price = productDTO.price;
        int result = await context.SaveChangesAsync();
        return (result > 0)?oldProduct:null;
    }//func
    
}//class