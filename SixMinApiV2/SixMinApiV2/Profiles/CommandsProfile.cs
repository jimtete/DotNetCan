using AutoMapper;
using SixMinApiV2.Dtos;
using SixMinApiV2.Models;

namespace SixMinApiV2.Profiles;

public class CommandsProfile : Profile
{
    public CommandsProfile()
    {
        // Source -> Target
        CreateMap<Command, CommandReadDto>();
        CreateMap<CommandCreateDto, Command>();
        CreateMap<CommandUpdateDto, Command>();

    }
}