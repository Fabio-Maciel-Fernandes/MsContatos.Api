using MsContatos.Core.Models;
using MsContatos.Infra.Consumers;
using MsContatos.Infra.Repositories.Interfaces;
using MsContatos.Infra.Repositories;
using MsContatos.Infra.Services.Interfaces;
using MsContatos.Infra.Services;
using Regioes.Infra.Consumers;
using MsContatos.Api.Middlewares;
using Npgsql;
using System.Data;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var connectionString = configuration.GetValue<string>("ConnectionStringPostgres");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IContatoServices, ContatoServices>();
builder.Services.AddSingleton<IServices<Compilacao>, CompilacaoServices>();
builder.Services.AddSingleton<IContatoRepository, ContatoRepository>();
builder.Services.AddSingleton<IRepository<Compilacao>, CompilacaoRepository>();
builder.Services.AddExceptionHandler<ExceptionHandler>();
//builder.Services.AddHostedService<InclusaoConsumer>();
//builder.Services.AddHostedService<UpdateConsumer>();
//builder.Services.AddHostedService<DeleteConsumer>();

builder.Services.AddSingleton<IDbConnection>((connection) => new NpgsqlConnection(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
