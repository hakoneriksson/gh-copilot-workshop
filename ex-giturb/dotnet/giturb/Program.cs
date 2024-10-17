var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDataStore<Urb>>(new InMemoryDataStore<Urb>(UrbsSeeder.SeedUrbs()));
builder.Services.AddSingleton<IDataStore<BasketOfUrbs>>(new InMemoryDataStore<BasketOfUrbs>());

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapUrbEndpoints();
app.MapBasketEndpoints();

// Default route to swagger
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.Run();

