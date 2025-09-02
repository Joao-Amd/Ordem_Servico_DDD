using Meraki.Cadastros.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meraki.Cadastros.Data.Maps.Clientes
{
    public class DadosCorporativosMap : IEntityTypeConfiguration<DadosCorporativo>
    {
        public void Configure(EntityTypeBuilder<DadosCorporativo> builder)
        {
            builder.ToTable("cliente_dados_corporativo");
            builder.HasKey(p => p.Id);

            builder.Property(c => c.RazaoSocial).HasColumnName("razao_social").HasMaxLength(200);
            builder.Property(c => c.Cnpj).HasColumnName("cnpj").HasMaxLength(14);
            builder.Property(c => c.NomeFantasia).HasColumnName("nome_fantasia").HasMaxLength(200);
            builder.Property(c => c.InscricaoEstadual).HasColumnName("inscricao_estadual").HasMaxLength(20);
            builder.Property(c => c.InscricaoMunicipal).HasColumnName("inscricao_municipal").HasMaxLength(20);

            builder.HasOne(p => p.Cliente)
                .WithOne(c => c.DadosCorporativo)
                .HasForeignKey<DadosCorporativo>(p => p.IdCliente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
