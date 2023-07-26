using SkillshotSpy.Entities;
using SkillshotSpy.Interfaces;
using SkillshotSpy.Parsers;
using SkillshotSpy.Scrapers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IParser<Offer>, OfferParser>();
builder.Services.AddScoped<IParser<Company>, CompanyParser>();
builder.Services.AddScoped<IScraper, ScraperService>();
builder.Services.AddHttpClient();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
