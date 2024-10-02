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

var app = builder.Build();

// Настройка остальных middleware (если есть)...

app.Run();