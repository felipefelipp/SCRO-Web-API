using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Cliente;

namespace Models.Data;

public class PessoaConfiguration<T> : IEntityTypeConfiguration<T> where T : Pessoa
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        
        builder
            .Property(p => p.Nome)
            .HasColumnName("nome")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(p => p.DataNascimento)
            .HasColumnName("DataNascimento");

        builder
            .Property(p => p.CPF)
            .HasColumnName("cpf")
            .HasColumnType("varchar(11)")
            .IsRequired();

        builder
            .Property(p => p.RG)
            .HasColumnName("rg")
            .HasColumnType("varchar(8)")
            .IsRequired();

        builder
            .Property(p => p.Celular)
            .HasColumnName("celular")
            .HasColumnType("varchar(11)")
            .IsRequired();

        builder
            .Property(p => p.Email)
            .HasColumnName("email")
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

        builder
            .HasIndex(p => p.CPF)
            .IsUnique();

        builder
            .HasIndex(p => p.Celular)
            .IsUnique();
    }
}
