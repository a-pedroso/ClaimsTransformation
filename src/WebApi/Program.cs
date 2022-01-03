using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.SetupServices();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.SetupRequestPipeline();

app.Run();