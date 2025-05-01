var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//1. localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//2. supported cualtures
var supportedCultures = new[] { "en-US", "es-ES", "fr-FR" }; //usa, spain, france
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0]) //english by default
    .AddSupportedCultures(supportedCultures) //add all supported cultures
    .AddSupportedUICultures(supportedCultures); //Add supported cultures to UI

//3 add localization to app
app.UseRequestLocalization(localizationOptions);

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
