using AutoMapper;
using Montech.Application.Services.AutoMapper;

namespace CommonTestUtilities.Mapper;

public static class MapperBuilder
{
    public static IMapper Build()
    {
        return new MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper();
    }
}

