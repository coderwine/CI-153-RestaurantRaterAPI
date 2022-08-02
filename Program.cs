//! ADD
using Microsoft.EntityFrameworkCore;
using RestaurantRaterAPI;
//!------

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//! INSTEAD OF THIS:
// public void ConfigureServices(IServiceCollection services) 
// {
//     services.AddControllers();
//     services.AddSwaggerGen(c =>
//     {
//         c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RestaurantRaterAPI", Version = "v1"});
//     });
//     services.AddHttpsRedirection(options => options.HttpsPort = 443);
// }
//! ---------------- USE THIS vvv
// builder.Services.AddDbContext<RestaurantDbContext>(options =. options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/** In appsettings.json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=RestaurantDB;User Id=sa;Password=3eLae*42w12;"
} 
under AllowedHost
**/
//! -----------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // used as: https://localhost:7015/swagger or https://localhost/swagger - depending on the workstation
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//! NOTES:
/**
    Installs:
        - dotnet dev-certs https --clean
        - dotnet dev-certs https --trust
            - Creates an SSL Certificate for the app.
            - Contains a public key that the server can use to validate incoming traffic.
                - https://www.cloudflare.com/learning/ssl/what-is-an-ssl-certificate/

    ORMS:
        - Object-Relational Mappers
        - In order to communicate with a DB with C# .Net, we translate our data into C# models (entities). These are virtual representations of the db.
        - Using EntityFramework as our ORM.
            - dotnet add package Microsoft.EntityFrameworkCore.SqlServer
            - dotnet add package Microsoft.EntityFrameworkCore.Design
            - dotnet tool install dotnet -ef

            - Allows us to set up models and a db context.

    Example notations:
        SQL
            CREATE TABLE dbo.Users
            (
                Id int NOT NULL PRIMARY KEY,
                Name nvarchar(100) NOT NULL,
                Email nvarchar(100) NOT NULL
            )

        C#
            public class User {
                [Key]
                public int Id {get; set;}
                [Required]
                [MaxLength(100)]
                public string Name {get; set;}
                [Required]
                [MaxLength(100)]
                public string Email {get; set;}
            }

            public DbSet<Users> {get; set;}

                - [Key]: est. Primary Key property. 
                - [Required]: denotes a required property
                - [MaxLength(#)]: limits the length of this property.
            
            - https://docs.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt
**/
