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

            // Adiciona o serviço de repositório e o serviço de negócios
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IUserService, UserService>();

            // Adiciona o serviço de controllers
            builder.Services.AddControllers();

            // Adiciona serviços da API (como OpenAPI, se necessário)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Adiciona CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()   // Permite qualquer origem
                           .AllowAnyMethod()   // Permite qualquer método HTTP
                           .AllowAnyHeader();  // Permite qualquer cabeçalho
                });
            });

            var app = builder.Build();

            // Configuração de middleware (como Swagger)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Ativa o CORS para a aplicação
            app.UseCors();

            // Configura os endpoints de controllers
            app.MapControllers();

            app.Run();
        }
    }
}
