using PersonsWebApp.ServiceContracts;
using PersonsWebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICountriesServices ,CountriesServices>();
builder.Services.AddSingleton<IPersonServices, PersonServices>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
