namespace UserManagementApi // Defina o namespace aqui
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

            var app = builder.Build();

            // Configura��o de middleware (como Swagger)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Configura os endpoints de controllers
            app.MapControllers();

            app.Run();
        }
    }
}
