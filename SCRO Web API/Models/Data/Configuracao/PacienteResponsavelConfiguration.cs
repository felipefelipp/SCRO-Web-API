using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCRO_Web_API.Models.Cliente;

namespace SCRO_Web_API.Models.Data.Configuracao;

public class PacienteResponsavelConfiguration : IEntityTypeConfiguration<PacienteResponsavel>
{
    public void Configure(EntityTypeBuilder<PacienteResponsavel> builder)
    {
        builder.ToTable("PacienteResponsavel");
    }
}
