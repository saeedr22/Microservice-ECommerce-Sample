using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.AddScoped<ISearchService, SearchService>();

builder.Services.AddHttpClient("OrdersService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Orders"]);
});
builder.Services.AddHttpClient("CustomersService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Customers"]);
});
builder.Services.AddHttpClient("ProductsService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Products"]);
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
app.MapRazorPages();
app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });


app.Run();
