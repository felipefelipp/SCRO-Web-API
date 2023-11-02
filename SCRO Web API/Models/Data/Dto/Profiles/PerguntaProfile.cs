using AutoMapper;
using Models.Classificacao;
using SCRO_Web_API.Models.Data.Dto.PerguntaDto;

namespace SCRO_Web_API.Models.Data.Dto.Profiles;

public class PerguntaProfile : Profile
{
    public PerguntaProfile()
    {
        CreateMap<Pergunta, ReadPerguntaDto>();
        CreateMap<CreatePerguntaDto, Pergunta>();
        CreateMap<UpdatePerguntaDto, Pergunta>();
    }
}
