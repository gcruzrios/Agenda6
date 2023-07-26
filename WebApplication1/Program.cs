using Agenda6.Modelos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configurar conexion SQL Server

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
   builder.Configuration.GetConnectionString("DefaultConnection")));
;



// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddRazorPages(options =>
//{
//    options.Conventions.AuthorizePage("/Home");
//    options.Conventions.AuthorizeFolder("/Privacy");
//    options.Conventions.AllowAnonymousToPage("/Usuarios/Login");
//    options.Conventions.AllowAnonymousToFolder("/Index");
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapRazorPages();

app.Run();
