using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCRO_Web_API.Models.Atendimento;

namespace SCRO_Web_API.Models.Data.Configuracao;

public class AtendimentoPacienteConfiguration : IEntityTypeConfiguration<AtendimentoPaciente>
{
    public void Configure(EntityTypeBuilder<AtendimentoPaciente> builder)
    {
        builder.ToTable("Atendimento");

        builder
            .Property(a => a.AtendimentoPacienteId)
            .HasColumnName("AtendimentoPacienteId")
            .HasDefaultValueSql("NEXT VALUE FOR AtendimentoSequence");

        builder.HasKey(a => a.AtendimentoPacienteId);

        builder
            .HasOne(c => c.ClassificacaoPaciente)
            .WithOne(a => a.AtendimentoPaciente)
            .HasForeignKey<AtendimentoPaciente>(a => a.AtendimentoPacienteId);

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
