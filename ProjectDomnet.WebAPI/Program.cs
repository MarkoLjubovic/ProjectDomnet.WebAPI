using Microsoft.EntityFrameworkCore;
using ProjectDomnet.Repository.Repository;
using ProjectDomnet.Repository.Repository.IRepository;
using ProjectDomnet.DAL.Data;
using ProjectDomnet.Service.Service;
using ProjectDomnet.Service.Service.IService;
using ProjectDomnet.WebAPI.MapperConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IVehicleMakeRepository, VehicleMakeRepository>();
builder.Services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();

builder.Services.AddScoped<IVehicleMakeService, VehicleMakeService>();
builder.Services.AddScoped<IVehicleModelService, VehicleModelService>();

builder.Services.AddAutoMapper(typeof(MapperConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
