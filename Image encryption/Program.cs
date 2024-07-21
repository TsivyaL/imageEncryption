////using DAL.Interfaces;
////using DAL.Data;
////using Microsoft.EntityFrameworkCore;
////using MODELS.Model;
////using Serilog;
////using Project.middleWare;
////using Microsoft.AspNetCore.Http;
////using BL.Interface;
////using BL.Services;
////using Image_encryption.middleWare;
////using AutoMapper;
////using AutoMapper.Extensions.Microsoft.DependencyInjection;
////using DAL.Profiles;
////using DAL.DTO;
////namespace Project
////{
////    public class Program
////    {
////        public static void Main(string[] args)
////        {
////            //string Cors = "_Cors";
////            var builder = WebApplication.CreateBuilder(args);

////            // Add services to the container.
////            builder.Services.AddControllers();
////            builder.Services.AddEndpointsApiExplorer();
////            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

////            builder.Services.AddSwaggerGen();
////            builder.Services.AddScoped<IUserService, UserService>();
////            builder.Services.AddScoped<IPictureService, PictureService>();
////            builder.Services.AddScoped<IUserData, UserData>();
////            builder.Services.AddScoped<IPictureData, PictureData>();


////            //builder.Services.AddCors(op =>
////            //{
////            //    op.AddPolicy(Cors, builder =>
////            //    {
////            //        builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
////            //    });
////            //});

////            builder.Services.AddDbContext<DBContext>(op => op.UseSqlServer("Data Source=DESKTOP-F77S003\\SQLEXPRESS01;Initial Catalog=s;Integrated Security=SSPI;Trusted_Connection=True;"));
////            Log.Logger = new LoggerConfiguration()
////             .WriteTo.File(@"c:/", rollingInterval: RollingInterval.Day)
////             .CreateLogger();

////            var app = builder.Build();

////            // Configure the HTTP request pipeline.
////            if (app.Environment.IsDevelopment())
////            {
////                app.UseSwagger();
////                app.UseSwaggerUI();
////            }

////            app.UseMiddleware<ErrorGlobalMiddleWare>();
////            app.UseMiddleware<Action_documentation>();
////            //app.UseCors(Cors);

////            app.UseHttpsRedirection();

////            app.UseAuthorization();

////            app.MapControllers();

////            app.Run();
////        }
////    }
////}

//using BL.Interface;
//using BL.Services;
//using DAL.Data;
//using DAL.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using MODELS.Model;
//using Project.middleWare;
//using System.Globalization;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddDbContext<DbContext>(op => op.UseSqlServer("Data Source=DESKTOP-F77S003\\SQLEXPRESS01;Initial Catalog=s;Integrated Security=SSPI;Trusted_Connection=True;"));
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IPictureService, PictureService>();
//builder.Services.AddScoped<IUserData, UserData>();
//builder.Services.AddScoped<IPictureData, PictureData>();
//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseMiddleware<ErrorGlobalMiddleWare>();
////app.UseMiddleware<Action_documentation>();
//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
using AutoMapper;
using DAL.Interfaces;
using DAL.Data;
using DAL.Profiles;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using MODELS.Model;
using System.Globalization;
using System.ComponentModel;
using BL.Interface;
using BL.Services;
using Project.middleWare;
namespace Image_encryption;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture(CultureInfo.InvariantCulture);
        });

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register IUser service
        builder.Services.AddScoped<IUserData, UserData>();
        builder.Services.AddScoped<IPictureData, PictureData>();
        builder.Services.AddScoped<IPictureService, PictureService>();
        builder.Services.AddScoped<IUserService, UserService>();
        // Add DbContext
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<DBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDataBase")));
        //// Add JWT authentication services
        //// Add JWT authentication services
        //builder.Services.AddAuthentication(options =>
        //{
        //    options.DefaultAuthenticateScheme = "JwtBearer";
        //    options.DefaultChallengeScheme = "JwtBearer";
        //}).AddJwtBearer("JwtBearer", jwtOptions =>
        //{
        //    jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        //    {
        //        // הגדרות אימות JWT כאן
        //    };
        //});
        // Add AutoMapper with the mapping profile
        builder.Services.AddAutoMapper(typeof(PictureProfile).Assembly);
        builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseMiddleware<ErrorGlobalMiddleWare>();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}