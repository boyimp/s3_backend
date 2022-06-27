//In the name of Allah

using Application.DBO;
using Application.Repositories;

public class ServiceFaccad
{
    protected readonly WebApplicationBuilder Builder;
    public ServiceFaccad(WebApplicationBuilder builder) => Builder = builder;//construcotr

    public void ServiceCollector()
    {
        Builder.Services.AddSingleton<IUserRepository, UserRepository>();
        Builder.Services.AddSingleton<IProductRepository, ProductRepository>();
        Builder.Services.AddSingleton<ITransactionRepository, TransactionRepository>();
        Builder.Services.AddEndpointsApiExplorer();
        Builder.Services.AddSwaggerGen();//service
        Builder.Services.AddDbContext<Data>(
            o => o.UseSqlServer(
                Builder.Configuration.GetConnectionString("DefaultConnecton")
                )
            );//service

    }//func
}//class