using BackEndApi.ExceptionHandler;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IKhoiRepository,KhoiRepository>();
builder.Services.AddScoped<ILopRepository,LopRepository>();
builder.Services.AddScoped<IDantocRepository,DanTocRepository>();
builder.Services.AddScoped<INguoiDungRepository,NguoiDungRepository>();
builder.Services.AddScoped<IChiTietLopHocRepository,ChiTietLopHocRepository>();
builder.Services.AddScoped<INamHocRepository,NamHocRepository>();
builder.Services.AddScoped<ITaiKhoanRepository,TaiKhoanRepository>();
//builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
//builder.Services.AddSingleton(typeof(ILogger), typeof(Logger));
builder.Services.AddLogging();

var DefaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(DefaultConnection, ServerVersion.AutoDetect(DefaultConnection)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
//var logger = app.Services.GetRequiredService<ILogger>();
app.ConfigureExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
