using Meraki.Api.Configuration;
using Meraki.Api.Extension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.ResolveDependencies();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddDbContexts(builder.Configuration);

var app = builder.Build();

//app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
