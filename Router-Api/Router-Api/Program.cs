using Router_Api.Data;
using Router_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    //options.UseMySql(builder.Configuration.GetConnectionString("AzureDeployment"), new MySqlServerVersion(new Version(5, 7, 31)));
});


builder.Services.AddScoped<IRouterApiService, RouterApiService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials
// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
