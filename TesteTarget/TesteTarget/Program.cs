using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TesteTarget",
        Description = "Sistema Target",
        TermsOfService = new Uri("https://github.com/lenilsonp40/Teste_Target"),
        Contact = new OpenApiContact
        {
            Name = "Lenilson Soares",
            Email = "lenilsonp40@gmail.com",
            Url = new Uri("https://github.com/lenilsonp40/Teste_Target"),
        },
        License = new OpenApiLicense
        {
            Name = "Usar sobre LICX",
            Url = new Uri("https://github.com/lenilsonp40/Teste_Target"),
        }
    });
});

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
