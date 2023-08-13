
using Game.Services;
using Game.Repositories;
using Game.Models.RequestModels;
using Game.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver =
            new DefaultContractResolver();
        options.SerializerSettings.ReferenceLoopHandling =
            ReferenceLoopHandling.Ignore;
    });
AddDI(builder.Services);
builder.Services.AddAutoMapper(typeof(Program).Assembly);


var app = builder.Build();

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

void AddDI(IServiceCollection services)
{
    services.AddScoped<NguoiDungRepository>();
    services.AddScoped<INguoiDungService, NguoiDungService>();
    services.AddScoped<NhanVatRepository>();
    services.AddScoped<INhanVatService, NhanVatService>();
    services.AddScoped<VuKhiRepository>();
    services.AddScoped<IVuKhiService, VuKhiService>();
    services.AddScoped<KyNangNhanVatRepository>();
    services.AddScoped<IKyNangNhanVatService, KyNangNhanVatService>();
    services.AddScoped<ClassRepository>();
    services.AddScoped<IClassService,ClassService>();

    services.AddScoped<KyNangRepository>();
    services.AddScoped<IKyNangService, KyNangService>();

}