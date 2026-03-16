using Microsoft.EntityFrameworkCore;
using SurveyManagementSystem.DAL.Data;
using SurveyManagementSystem.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adding Swagger services to the container for API testing
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddTransient<IUser, UserRepository>();
builder.Services.AddScoped<IUser, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//For Swagger services
//app.UseSwagger();
//app.UseSwaggerUI();
