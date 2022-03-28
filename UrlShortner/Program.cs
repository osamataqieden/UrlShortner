using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UrlShortner.Data.IURlRepository, UrlShortner.Data.RelationalUrlRepository>();
builder.Services.AddScoped<UrlShortner.Services.IUrlService, UrlShortner.Services.UrlService>();
builder.Services.AddDbContext<UrlShortner.Data.ApplicationDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
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

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();
