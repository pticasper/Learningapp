using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Configuration.AddAzureAppConfiguration(
    options =>
    {
        options.Connect("Endpoint=https://applicationconfigbyme.azconfig.io;Id=uzy0;Secret=1HPriZwJdNlB75vimrBpryG0BmMqnWHMW90AsyrYkFkntwxb3Tw2JQQJ99BBACBsN54ZAx3ZAAABAZACWthm");
        options.UseFeatureFlags();
    }
     );
builder.Services.AddFeatureManagement();
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

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
