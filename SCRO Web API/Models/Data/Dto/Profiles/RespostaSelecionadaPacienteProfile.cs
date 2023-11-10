using AutoMapper;
using Models.Classificacao;
using SCRO_Web_API.Models.Data.Dto.RespostaSelecionadaPacienteDto;

namespace SCRO_Web_API.Models.Data.Dto.Profiles;

public class RespostaSelecionadaPacienteProfile : Profile
{
    public RespostaSelecionadaPacienteProfile()
    {
        CreateMap<RespostaSelecionadaPaciente, ReadRespostaSelecionadaPacienteDto>();
        CreateMap<CreateRespostaSelecionadaPacienteDto, RespostaSelecionadaPaciente>();
        CreateMap<UpdateRespostaSelecionadaPacienteDto, RespostaSelecionadaPaciente>();
    }
}
