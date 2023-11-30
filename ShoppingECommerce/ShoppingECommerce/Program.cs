using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShoppingEcomerceCommon.Model;
using ShoppingEcommerceLogic.InterFace;
using ShoppingEcommerceLogic.Logic;
using ShoppingEcommerceRepo.Interface;
using ShoppingEcommerceRepo.Repositry;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace ShoppingECommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            Databasesetting.connectionstring = builder.Configuration["ConnectionStrings:Connect"];

            builder.Services.AddScoped<IAuthLogic, AuthLogic>();
            builder.Services.AddScoped<IAuthrepo, Authrepo>();
            builder.Services.AddScoped<Iadminproductaddrepo, adminproductaddrepo>();
            builder.Services.AddScoped<Iadminproductaddlogic, adminproductaddlogic>();
            builder.Services.AddScoped<Icategroyrepo, categroyrepo>();
            builder.Services.AddScoped<Icategroylogic, categroylogic>();
            builder.Services.AddScoped<Iaddcartrepo, Addcartrepo>();
            builder.Services.AddScoped<Iaddcartlogic, addcartlogic>();

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = " standard authorization header using the Bearer scheme (\"bearere { token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.MapControllers();

            app.Run();
        }
    }
}