using Microsoft.EntityFrameworkCore;
using SurveyManagementSystem.DAL.Data;
using SurveyManagementSystem.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adding Swagger services to the container for API testing
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddControllers();


//Added service for CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowUI", policy =>
    {
        policy.WithOrigins("https://localhost:7264")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IRole, RoleRepository>();
builder.Services.AddScoped<IUser, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    //For Swagger services
    //app.UseSwagger();
    //app.UseSwaggerUI();

}

app.UseHttpsRedirection();

//allowing UI to access the Web API i.e using CORS service that is registered
app.UseCors("AllowUI");

app.UseAuthorization();

app.MapControllers();

app.Run();

