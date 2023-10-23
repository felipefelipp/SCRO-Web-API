﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Classificacao;

namespace Models.Data.Configuracao
{
    public class ClassificacaoPacienteConfiguration : IEntityTypeConfiguration<ClassificacaoPaciente>
    {
        public void Configure(EntityTypeBuilder<ClassificacaoPaciente> builder)
        {
            builder
                .ToTable("ClassificacaoPaciente");

            builder
                .Property(cpc => cpc.ClassificacaoPacienteId)
                .HasColumnName("ClassificacaoPacienteId");

            builder
                .Property(cpc => cpc.ValorResultadoClassificacao)
                .HasColumnName("ValorResultadoClassificacao");

            builder
                .Property(cpc => cpc.ResultadoCor)
                .HasColumnName("ValorResultadoCor");

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
}
