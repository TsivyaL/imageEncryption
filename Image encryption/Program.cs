using DAL;
using Microsoft.EntityFrameworkCore;
using MODELS.Model;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<DBContext>(op => op.UseSqlServer("Data Source=Data Source=localhost\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=SSPI;Trusted_Connection=True;"));
//builder.Services.AddScoped<IBookData, BookData>();
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
