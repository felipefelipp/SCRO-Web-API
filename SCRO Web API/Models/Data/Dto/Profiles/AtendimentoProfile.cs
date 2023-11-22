using AutoMapper;
using Models.Cliente;
using SCRO_Web_API.Models.Atendimento;
using SCRO_Web_API.Models.Data.Dto.AtendimentoDto;
using SCRO_Web_API.Models.Data.Dto.PacienteDto;

namespace SCRO_Web_API.Models.Data.Dto.Profiles;

public class AtendimentoProfile : Profile
{
    public AtendimentoProfile()
    {
        CreateMap<AtendimentoPaciente, ReadAtendimentoDto>();
        CreateMap<CreateAtendimentoDto, AtendimentoPaciente>();
        CreateMap<UpdateAtendimentoDto, AtendimentoPaciente>();
    }
}
