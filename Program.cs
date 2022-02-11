using Microsoft.EntityFrameworkCore;
using WebApi.DbContexts;
using WebApi.Helpers;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    services.AddCors();
    services.AddControllers();

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // configure DI for application services
    services.AddScoped<IUserService, UserService>();
}



//var connectionString = builder.Configuration.GetConnectionString("Default");
//builder.Services.AddDbContext<MyDBContext>(x => x.UseSqlServer(connectionString));

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<MyDBContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});




var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}

app.Run();

//app.Run("http://localhost:5000");