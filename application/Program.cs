// In the name of Allah

global using Microsoft.EntityFrameworkCore;
using Application.Endpoints;

//builder
var builder = WebApplication.CreateBuilder(args);
new ServiceFaccad(builder).ServiceCollector();
var MyAllowSpecificOrigins = "myPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin();
                      });
});

//application
var app = builder.Build();

//middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}//if
app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/",()=>"Allah is Almighty!");

//endpoints
new UserEndpoints(app).EndpointDefinition();
new ProductEndpoints(app).EndpointDefinition();
new TransactionEndpoints(app).EndpointDefinition();


//start
app.Run();
