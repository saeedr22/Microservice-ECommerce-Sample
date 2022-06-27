using ECommerce.Api.Customers.Data;
using ECommerce.Api.Customers.Interfaces;
using ECommerce.Api.Customers.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ICustomersProvider, CustomersProvider>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<CustomersDbContext>(options =>
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
app.UseAuthorization();
app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllers();
           });


app.MapRazorPages();

app.Run();
