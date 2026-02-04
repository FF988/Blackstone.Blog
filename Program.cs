using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Blackstone.Repoistory;
using Blackstone;

// using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

// --- 設定 CORS ---
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "黑石資訊 Blog Demo API",
        Version = "v1"
    });

});

// builder.Services.AddSwaggerGen();
// 配置授權 (Authorization)
builder.Services.AddAuthorization();

// --- 設定 DbContext ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

// --- 註冊 Controller 服務 ---
builder.Services.AddControllers(); // 重要：加入 Controller 支援

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<BlogCategoryRepository>();
builder.Services.AddScoped<BlogRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) // 建議僅在開發環境開啟
{
    app.UseSwagger();   // 產生 Swagger JSON 說明文件
    app.UseSwaggerUI();  // 產生可視化的網頁畫面
}
// app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);

app.UseAuthentication(); // 認證：你是誰？
app.UseAuthorization();  // 授權：你能做什麼？

// --- 映射 Controller 路由 ---
app.MapControllers(); // 重要：告訴 .NET 去尋找 Controller 類別

app.Run();