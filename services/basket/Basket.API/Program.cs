using Basket.Application.Commands;
using Basket.Application.Mapper;
using Basket.Domain.Repositories;
using Basket.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(BasketMappingProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly(),
    Assembly.GetAssembly(typeof(UpdateShoppingCartCommand))

    ));
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
});


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Basket API",
        Version = "v1",
        Description = "This is Api for Basket Microservices Ecommerce Applications",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Nourhan Shaban",
            Email = "nourhashaban689@gmail.com",
            Url = new Uri("https://yourwebsite.eg")
        }
    });

});


builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
