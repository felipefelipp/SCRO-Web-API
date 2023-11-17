using AutoMapper;
using SCRO_Web_API.Models.Classificacao;
using SCRO_Web_API.Models.Data.Dto.ResultadoDto;

namespace SCRO_Web_API.Models.Data.Dto.Profiles;

public class ResultadoProfile : Profile
{
    public ResultadoProfile()
    {
        CreateMap<Resultado, ReadResultadoDto>();
        CreateMap<CreateResultadoDto, Resultado>();
    }
}
