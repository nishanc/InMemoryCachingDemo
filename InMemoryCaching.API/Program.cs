using InMemoryCaching.Data.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add memory cache dependencies 
builder.Services.AddMemoryCache(options =>
{
    // Overall 1024 size (no unit)
    // options.SizeLimit = 1024;
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
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
