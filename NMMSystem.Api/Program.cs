using Microsoft.EntityFrameworkCore;
using NMMSystem.Aplication.Service.AddressInfoServ;
using NMMSystem.Aplication.Service.ContactInfromationServ;
using NMMSystem.Aplication.Service.PrivateInfromationServ;
using NMMSystem.Aplication.Service.ProductServ;
using NMMSystem.Aplication.Service.SaleServ;
using NMMSystem.Aplication.Service.SupplierRecomendatorsServ;
using NMMSystem.Aplication.Service.SupplierServ;
using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IContext, Context>();
builder.Services.AddScoped<IContactInformationService, ContactInformationService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IPrivateInfromationService, PrivateInfromationService>();
builder.Services.AddScoped<IAddressInfoService, AddressInfoService>();
builder.Services.AddScoped<ISupplierSaleService, SupplierSaleService>();
builder.Services.AddScoped<ISupplierRecomendatorsService, SupplierRecomendatorsService>();

builder.Services.AddAutoMapper(typeof(RegistrationAutoMapperProfile).Assembly);

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
