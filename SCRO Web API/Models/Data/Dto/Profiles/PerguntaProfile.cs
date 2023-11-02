using AutoMapper;
using Models.Classificacao;
using SCRO_Web_API.Models.Data.Dto.PerguntaDto;

namespace SCRO_Web_API.Models.Data.Dto.Profiles;

public class PerguntaProfile : Profile
{
    public PerguntaProfile()
    {
        CreateMap<Pergunta, ReadPerguntaDto>()
            .ForMember(dto => dto.CategoriaPergunta, opt => opt.MapFrom(CategoriaPergunta => CategoriaPergunta.CategoriaPergunta));
        CreateMap<CreatePerguntaDto, Pergunta>();
        CreateMap<UpdatePerguntaDto, Pergunta>();
    }
}
