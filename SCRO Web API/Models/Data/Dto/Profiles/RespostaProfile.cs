using AutoMapper;
using Models.Classificacao;
using SCRO_Web_API.Models.Data.Dto.RespostaDto;

namespace SCRO_Web_API.Models.Data.Dto.Profiles;

public class RespostaProfile : Profile
{
    public RespostaProfile()
    {
        CreateMap<Resposta, ReadRespostaDto>();
        CreateMap<CreateRespostaDto, Resposta>();
        CreateMap<UpdateRespostaDto, Resposta>();
    }
}
