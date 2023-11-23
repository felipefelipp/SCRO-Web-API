using AutoMapper;
using SCRO_Web_API.Models.Cliente;
using SCRO_Web_API.Models.Data.Dto.PacienteResponsavelDto;

namespace SCRO_Web_API.Models.Data.Dto.Profiles;

public class PacienteResponsavelProfile : Profile
{
    public PacienteResponsavelProfile()
    {
        CreateMap<PacienteResponsavel, ReadPacienteResponsavelDto>();
        CreateMap<CreatePacienteResponsavelDto, PacienteResponsavel>();
        CreateMap<UpdatePacienteResponsavelDto, PacienteResponsavel>();
    }
}
