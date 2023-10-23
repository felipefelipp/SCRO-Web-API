using AutoMapper;
using Models.Cliente;
using SCRO_Web_API.Models.Data.Dto.PacienteDto;

namespace SCRO_Web_API.Models.Data.Dto.Profiles;

public class PacienteProfile : Profile
{
    public PacienteProfile()
    {
        CreateMap<Paciente, ReadPacienteDto>();
        CreateMap<CreatePacienteDto, Paciente>();
        CreateMap<UpdatePacienteDto, Paciente>();
    }
}
