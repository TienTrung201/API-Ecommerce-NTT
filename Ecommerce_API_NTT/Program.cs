using Ecommerce_API.Core.Initial;
using Ecommerce_API.Repositories.Repositories;
using Ecommerce_API.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EcommerceDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Ecommerce");
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Ecommerce_API_NTT"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAddressService, AddressService>();


// Add Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyHeader();
    });
});
//builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Add auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
