using AutoMapper;
using Montech.Communication.Requests.Usuario;
using Montech.Communication.Responses.Usuario;

namespace Montech.Application.Services.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
        DomainToResponse();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegistrarUsuarioJson, Domain.Entities.Usuario>()
            .ForMember(dest => dest.Senha, opt => opt.Ignore());

        //CreateMap<RequestAtualizarUsuarioJson, Domain.Entities.Usuario>();
    }

    private void DomainToResponse()
    {
        CreateMap<Domain.Entities.Usuario, ResponseUserProfileJson>();
    }
}