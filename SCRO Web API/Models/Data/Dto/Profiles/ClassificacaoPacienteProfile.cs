using AutoMapper;
using Models.Classificacao;
using SCRO_Web_API.Models.Data.Dto.ClassificacaoPacienteDto;

namespace SCRO_Web_API.Models.Data.Dto.Profiles;

public class ClassificacaoPacienteProfile : Profile
{
    public ClassificacaoPacienteProfile()
    {
        CreateMap<ClassificacaoPaciente, ReadClassificacaoPacienteDto>();
        CreateMap<CreateClassificacaoPacienteDto, ClassificacaoPaciente>();
        CreateMap<UpdateClassificacaoPacienteDto, ClassificacaoPaciente>();
    }
}
