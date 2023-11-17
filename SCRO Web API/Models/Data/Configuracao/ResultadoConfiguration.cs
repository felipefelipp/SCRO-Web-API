using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCRO_Web_API.Models.Classificacao;

namespace SCRO_Web_API.Models.Data.Configuracao;

public class ResultadoConfiguration : IEntityTypeConfiguration<Resultado>
{
    public void Configure(EntityTypeBuilder<Resultado> builder)
    {
        builder.ToTable("Resultado");

        builder.Property(r => r.ResultadoId)
               .HasDefaultValueSql("NEXT VALUE FOR ResultadoSequence");

        builder.Property(r => r.ResultadoClassificacaoCor)
               .HasColumnName("ResultadoClassificacaoCor")
               .HasColumnType("varchar(100)");

        builder
           .Property<DateTime>("InseridoEm")
           .HasColumnType("datetime")
           .HasDefaultValueSql("getdate()");

        builder
            .Property<int>("InseridoPor")
            .HasColumnType("int")
            .HasDefaultValueSql("1"); //Implementar inserido por usuário X ou Y

        builder
            .Property<DateTime>("ModificadoEm")
            .HasColumnType("datetime")
            .HasDefaultValueSql("getdate()"); //Implementar modificado em 

        builder
            .Property<int>("ModificadoPor")
            .HasColumnType("int")
            .HasDefaultValueSql("1"); //Implementar usuário que modificou
    }
}
