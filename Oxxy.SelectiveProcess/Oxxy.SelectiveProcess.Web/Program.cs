using Oxxy.SelectiveProcess.Web.Services;
using Oxxy.SelectiveProcess.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);


//Injeção da referencia dos serviços
builder.Services.AddHttpClient<IVehicleService, VehicleService>(c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:VehicleAPI"]));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vehicle}/{action=Index}/{id?}");

app.Run();
