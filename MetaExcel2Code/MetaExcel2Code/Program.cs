using MetaExcel2Code.Config;
using MetaExcel2Code.WS;

var builder = WebApplication.CreateBuilder(args);

// 注册控制器服务
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSignalR();

builder.Services.AddOpenApi();

// 显式指定端口
builder.WebHost.UseUrls("http://localhost:5000");

var app = builder.Build();

// 启用静态文件访问（如前端页面）
app.UseStaticFiles();

// 启用路由
app.UseRouting();

// 配置 WebSocket 支持
app.UseWebSockets();

// 全局异常
app.UseMiddleware<GlobalExceptionMiddleware>();

// RESTful 路由
app.MapControllers();

// 配置 WebSocket 路由
app.MapHub<ExcelHub>("excel");

app.Run();