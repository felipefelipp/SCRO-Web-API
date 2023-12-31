﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Classificacao;

namespace Models.Data.Configuracao;

public class CategoriaPerguntaConfiguration : IEntityTypeConfiguration<CategoriaPergunta>
{
    public void Configure(EntityTypeBuilder<CategoriaPergunta> builder)
    {
        builder
            .ToTable("CategoriaPergunta");

        builder
            .Property(cp => cp.CategoriaPerguntaId)
            .HasColumnName("CategoriaPerguntaId")
            .HasDefaultValueSql("NEXT VALUE FOR CategoriaPerguntaSequence"); 

        builder
            .Property(cp => cp.Descricao)
            .HasColumnName("Descricao")
            .HasColumnType("varchar(100)")
            .IsRequired();

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
