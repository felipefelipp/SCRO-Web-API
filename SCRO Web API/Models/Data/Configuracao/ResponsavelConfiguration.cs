using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Cliente;

namespace Models.Data;

public class ResponsavelConfiguration : PessoaConfiguration<Responsavel>
{
    public override void Configure(EntityTypeBuilder<Responsavel> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("Responsavel");

        builder
            .Property(r => r.ResponsavelId)
            .HasColumnName("ResponsavelId")
            .HasDefaultValueSql("NEXT VALUE FOR ResponsavelSequence");

        builder
            .HasKey(r => r.ResponsavelId);  

    }
}
