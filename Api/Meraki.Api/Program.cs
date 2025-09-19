using Meraki.Api.Configuration;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.ResolveDependencies();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.Formatting = Formatting.Indented;
    });

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

//Roda o docker-compose para subir os containers no ambiente
var projectRoot = app.Services.GetRequiredService<IWebHostEnvironment>().ContentRootPath;
DockerComposeConfig.RunDockerCompose(projectRoot);

//Roda os migrations pendentes no ambiente de desenvolvimento
using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<DataBaseInitializer>().Initialize();

app.Run();
