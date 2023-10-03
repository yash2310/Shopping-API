using Microsoft.EntityFrameworkCore;
using Shopping.Shared.Constants;
using Shopping.Shared.Middleware;
using Shopping.User.Business;
using Shopping.User.Business.Service;
using Shopping.User.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UserDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString(Constants.DBConstant.UserDbConnectionString));
});

builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

#region Code to enable serilog logging
var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());
#endregion

#region Code to update database based on latest migration (For production environment)
var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
await dbContext.Database.MigrateAsync();
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<HttpLoggingMiddleware>();

app.MapControllers();

app.Run();
