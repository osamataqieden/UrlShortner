var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddRazorPages();
                //.AddMvcLocalization();
builder.Services.AddControllers();
builder.Services.AddScoped<UrlShortner.Data.IURlRepository, UrlShortner.Data.RelationalUrlRepository>();
builder.Services.AddScoped<UrlShortner.Services.IUrlService, UrlShortner.Services.UrlService>();
builder.Logging.ClearProviders();
builder.Logging.AddFile("logs/log-{Date}.txt");

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

//var cultures = new[] { "en", "ar" };
//var LocalizationOptions = new RequestLocalizationOptions()
//                              .AddSupportedCultures(cultures)
//                              .AddSupportedUICultures(cultures);
//LocalizationOptions.RequestCultureProviders.RemoveAt(0);
//LocalizationOptions.RequestCultureProviders.RemoveAt(1);
//app.UseRequestLocalization(LocalizationOptions);

app.UseRouting();

app.MapRazorPages();

app.MapControllers();

app.Run();
