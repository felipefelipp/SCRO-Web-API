using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Models.Data.Contexto;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var conectionString = builder.Configuration.GetConnectionString("SCROConection");
builder.Services.AddDbContext<SCROContext>(opts =>
{
    opts.UseLazyLoadingProxies().UseSqlServer(conectionString, sqlServerOptionsAction: sqlServerOptions =>
    {
        sqlServerOptions.MigrationsAssembly(typeof(SCROContext).Assembly.FullName);
        sqlServerOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
    });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddControllers().AddNewtonsoftJson();
//builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(opcoes =>
{

    opcoes.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Version = "v1",
        Title = "SCROWEBAPI",
        Description = "API destinada ao sistema de classificação de risco para gestantes e puérperas",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Felipe Santos",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opcoes.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
