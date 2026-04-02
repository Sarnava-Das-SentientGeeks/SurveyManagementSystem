
using SMSWeb.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddAuthentication().AddCookie("MyCookieAuth", (options) =>
{
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly",
        policy => policy.RequireClaim("Admin"));

    options.AddPolicy("MustBelongToAdmin",
        policy => policy.RequireClaim("Role", "Admin"));
});



builder.Services.AddRazorPages();


//builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped(u => new HttpClient { BaseAddress = new Uri("https://localhost:7275") });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
