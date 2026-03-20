using Microsoft.EntityFrameworkCore;
using SurveyManagementSystem.BLL.Mappings;
using SurveyManagementSystem.DAL.Data;
using SurveyManagementSystem.DAL.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Adding Swagger services to the container for API testing
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

//Added mapping services from entity to DTOs
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(typeof(UserMapperProfile));
});


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


// Added service for api json file at https://localhost:7275/openapi/v1.json
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

