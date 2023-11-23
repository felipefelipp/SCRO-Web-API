using AutoMapper;
using Models.Cliente;
using SCRO_Web_API.Models.Data.Dto.ResponsavelDto;

namespace SCRO_Web_API.Models.Data.Dto.Profiles;

public class ResponsavelProfile : Profile
{
    public ResponsavelProfile()
    {
        CreateMap<Responsavel, ReadResponsavelDto>();
            //.ForMember(dto => dto.Paciente, opt => opt.MapFrom(paciente => paciente.Paciente));
        CreateMap<CreateResponsavelDto, Responsavel>();
        CreateMap<UpdateResponsavelDto, Responsavel>();
    }
}
