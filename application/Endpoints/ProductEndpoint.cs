// In the name of Allah

using Application.DBO;
using Application.Models;
using Application.Repositories;
using Application.Utils;

namespace Application.Endpoints;

public class ProductEndpoints : Endpoint
{
    public ProductEndpoints(WebApplication application) : base(application) { }//constructor

    public override void EndpointDefinition()
    {
        Application.MapGet(Routes.PRODUCT_GET, GetProducts);
        Application.MapGet(Routes.PRODUCT_GET_BY_NAME, GetProductByName);
        Application.MapPost(Routes.PRODUCT_ADD, AddProduct);
        Application.MapPut(Routes.PRODUCT_UPDATE, UpdateProduct);
        Application.MapDelete(Routes.PRODUCT_REMOVE, RemoveProduct);
        
    }//func

    public static async Task<IResult> GetProducts
    (
        IProductRepository repository, 
        Data context
        )
    {
        List<Product> products = await repository.GetProducts(context);
        return Results.Ok(products);
    }//func

    public static async Task<IResult> GetProductByName
    (
        string name, 
        IProductRepository repository, 
        Data context
        )
    {
        if (String.IsNullOrEmpty(name)) return Results.BadRequest();

        var product = await repository.GetProductByName(name, context);

        return (product is null) 
            ? Results.NotFound() 
            : Results.Ok(product);

    }//func

    public static async Task<IResult> AddProduct
    (
        ProductDTO productDTO,
        IProductRepository repository,
        Data context
        )
    {
        if (String.IsNullOrEmpty(productDTO.name)
                ||
                String.IsNullOrEmpty(productDTO.price.ToString())
                ) return Results.BadRequest();

        var product = await repository.AddProduct(productDTO, context);
        return (product is null)
            ? Results.NotFound()
            : Results.Ok(product);
    }//func

    public static async Task<IResult> UpdateProduct
    (
        string oldProductName, 
        ProductDTO productDTO, 
        IProductRepository repository, 
        Data context
        )
    {
        var product = await repository.UpdateProduct(oldProductName, productDTO, context);

        return (product is null) 
            ? Results.NotFound() 
            : Results.Ok(product);

    }//func

    public static async Task<IResult> RemoveProduct
    (
        string productName, 
        IProductRepository repository, 
        Data context
        )
    {
        var product = await repository.RemoveProduct(productName, context);

        return (product is null) 
            ? Results.NotFound() 
            : Results.Ok(product);

    }//func

}//class