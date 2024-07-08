using BackEndApi.ExceptionHandler;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddScoped<IKhoiRepository, KhoiRepository>();
builder.Services.AddScoped<ILopRepository, LopRepository>();
builder.Services.AddScoped<IDantocRepository, DanTocRepository>();
builder.Services.AddScoped<INguoiDungRepository, NguoiDungRepository>();
builder.Services.AddScoped<IChiTietLopHocRepository, ChiTietLopHocRepository>();
builder.Services.AddScoped<INamHocRepository, NamHocRepository>();
builder.Services.AddScoped<ITaiKhoanRepository, TaiKhoanRepository>();
builder.Services.AddScoped<IKhoaHocRepository, KhoaHocRepository>();
builder.Services.AddScoped<IUploadImageRepository, UploadImageRepository>();
builder.Services.AddScoped<ITonGiaoRepository, TonGiaoRepository>();
builder.Services.AddScoped<IMonHocRepository, MonHocRepository>();
builder.Services.AddScoped<ICaHocRepository, CaHocRepository>();
builder.Services.AddScoped<ITietHocRepository, TietHocRepository>();
builder.Services.AddScoped<IKyHocRepository, KyHocRepository>();
builder.Services.AddScoped<IHocBaRepository, HocBaRepository>();
builder.Services.AddScoped<IKyThiRepository, KyThiRepository>();
builder.Services.AddScoped<IDiemThiRepository, DiemThiRepository>();
builder.Services.AddScoped<IChiTietKyThiRepository, ChiTietKyThiRepository>();
builder.Services.AddScoped<IMonThiRepository, MonThiRepository>();
builder.Services.AddScoped<IThoiKhoaBieuRepository, ThoiKhoaBieuRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyOrigin();
                      });
});
//builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
//builder.Services.AddSingleton(typeof(ILogger), typeof(Logger));
builder.Services.AddLogging();

var DefaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(DefaultConnection, ServerVersion.AutoDetect(DefaultConnection)));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new NullableGuidConverter());
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
}); ;
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
app.UseCors(MyAllowSpecificOrigins);
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(), "image")),
    RequestPath = "/image"
});
app.UseAuthorization();

app.MapControllers();

app.Run();
