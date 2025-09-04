var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to listen on port 80 inside Docker
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(80);
//});

// Add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Disable HTTPS redirection in Docker
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
