using AutoMapper;
using Models.Classificacao;
using SCRO_Web_API.Models.Data.Dto.CategoriaPerguntaDto;

namespace SCRO_Web_API.Models.Data.Dto.Profiles;

public class CategoriaPerguntaProfile : Profile
{
    public CategoriaPerguntaProfile()
    {
        CreateMap<CategoriaPergunta, ReadCategoriaPerguntaDto>();
        CreateMap<CreateCategoriaPerguntaDto, CategoriaPergunta>();
        CreateMap<UpdateCategoriaPerguntaDto, CategoriaPergunta>();
    }
}
