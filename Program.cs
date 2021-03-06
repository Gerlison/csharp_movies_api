using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;


var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MySqlServerVersion(new Version(8,0,28));
builder.Services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("AppDbContext"), serverVersion));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
