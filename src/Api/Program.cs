namespace UserManagementApi 
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using UserManagementApi.Repositories;
    using UserManagementApi.Services;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona o servi�o de reposit�rio e o servi�o de neg�cios
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IUserService, UserService>();

            // Adiciona o servi�o de controllers
            builder.Services.AddControllers();

            // Adiciona servi�os da API (como OpenAPI, se necess�rio)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Adiciona CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()   // Permite qualquer origem
                           .AllowAnyMethod()   // Permite qualquer m�todo HTTP
                           .AllowAnyHeader();  // Permite qualquer cabe�alho
                });
            });

            var app = builder.Build();

            // Configura��o de middleware (como Swagger)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Ativa o CORS para a aplica��o
            app.UseCors();

            // Configura os endpoints de controllers
            app.MapControllers();

            app.Run();
        }
    }
}
