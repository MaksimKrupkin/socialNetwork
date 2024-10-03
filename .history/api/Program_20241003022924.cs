using api.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using api.Data;

var builder = WebApplication.CreateBuilder(args);



// Получаем строку подключения из appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Подключаем PostgreSQL в DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Добавляем контроллеры и другие сервисы
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Настройка остальных middleware (если есть)...

app.Run();