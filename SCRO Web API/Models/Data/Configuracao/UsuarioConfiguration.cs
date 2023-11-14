using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Funcionario;

namespace Models.Data;

public class UsuarioConfiguration : PessoaConfiguration<Usuario>
{
    public override void Configure(EntityTypeBuilder<Usuario> builder)
    {

        builder
            .ToTable("Usuario");

        builder
            .Property(u => u.UsuarioId)
            .HasColumnName("UsuarioId")
            .HasDefaultValueSql("NEXT VALUE FOR UsuarioSequence");

        base.Configure(builder);

        builder
            .Property(u => u.COREN)
            .HasColumnName("coren")
            .HasColumnType("varchar(8)");

        builder
            .Property(u => u.CRM)
            .HasColumnName("crm")
            .HasColumnType("varchar(8)");

        builder
            .Property(u => u.Senha)
            .HasColumnName("senha")
            .HasColumnType("varchar(8)")
            .IsRequired();
    }
}
