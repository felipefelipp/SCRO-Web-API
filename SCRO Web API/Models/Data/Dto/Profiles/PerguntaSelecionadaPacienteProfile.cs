using AutoMapper;
using Models.Classificacao;
using SCRO_Web_API.Models.Data.Dto.PerguntaSelecionadaPacienteDto;

namespace SCRO_Web_API.Models.Data.Dto.Profiles;

public class PerguntaSelecionadaPacienteProfile : Profile
{
    public PerguntaSelecionadaPacienteProfile()
    {
        CreateMap<PerguntaSelecionadaPaciente, ReadPerguntaSelecionadaPacienteDto>();
        CreateMap<CreatePerguntaSelecionadaPacienteDto, PerguntaSelecionadaPaciente>();
        CreateMap<UpdatePerguntaSelecionadaPacienteDto, PerguntaSelecionadaPaciente>();
    }
}
