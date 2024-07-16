using WebApi_Test.Src.Interfaces;
using WebApi_Test.Src.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//provide services
builder.Services.AddScoped<IScopedPickRandomNumber, ScopedPickRandomNumber>();
builder.Services.AddSingleton<ISingltonPickRandomNumber, SingltonPickRandomNumber>();
builder.Services.AddTransient<ITransiantPickRandomNumber, TransiantPickRandomNumber>();



builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
