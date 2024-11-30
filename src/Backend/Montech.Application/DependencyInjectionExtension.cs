using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Montech.Application.Services.AutoMapper;
using Montech.Application.Services.Cryptography;
using Montech.Application.UseCases.Usuario.Buscar;
using Montech.Application.UseCases.Usuario.BuscarAtivos;
using Montech.Application.UseCases.Usuario.Criar;
using Montech.Application.UseCases.Usuario.Deletar;
using Montech.Application.UseCases.Usuario.Login.DoLogin;
using Montech.Application.UseCases.Usuario.Registrar;

namespace Montech.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration confiruation)
    {
        AddUseCases(services);
        AddAutoMapper(services);
        AddPasswordEcrypter(services, confiruation);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>();
        services.AddScoped<IBuscarUsuarioIdUseCase, BuscarUsuarioIdUseCase>();
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
        services.AddScoped<IGetActivesUsersUseCase, GetActiveUsersUseCase>();
        services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper());
    }

    private static void AddPasswordEcrypter(IServiceCollection services, IConfiguration confiruation)
    {
        var aditionalKey = confiruation.GetSection("Settings:Password:AdditionalKey").Value;

        services.AddScoped(option => new CriptografiaSenha(aditionalKey!));
    }
}
