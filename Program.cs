using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoListAPI.Data;
using ToDoListAPI.Services;
using ToDoListAPI.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Adding our services
builder.Services.AddDbContext<AppDbContext>(
    options =>
    options.UseMySql(
        "server=localhost;database=TodoList;user=root;password=Magic@1234@",
        new MySqlServerVersion(new Version(8, 0, 36))
    )
);

builder.Services.AddScoped<ITokenService, TokenService>();

// Adding JWT auth service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        var tokenKey = builder.Configuration["TokenKey"] ?? throw new Exception("Token key not found in config files");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapGet("/", () => new { status = 200, message = "The server is up and running" });

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
