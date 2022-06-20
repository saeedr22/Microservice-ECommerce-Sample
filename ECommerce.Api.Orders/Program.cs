using ECommerce.Api.Orders.Data;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IOrdersProvider, OrdersProvider>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<OrdersDbContext>(options =>
{
    options.UseInMemoryDatabase("Products");
});

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
app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllers();
           });
app.UseAuthorization();

app.MapRazorPages();

app.Run();
