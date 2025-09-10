using Meraki.Estoque.Domain.Itens;
using Meraki.Estoque.Domain.Unidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meraki.Estoque.Data.Maps.Unidades
{
    public class UnidadeMap : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.ToTable("unidadade");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedNever();

            builder.Property(p => p.Sigla)
                .HasColumnName("sigla")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(p => p.Fator)
                .HasColumnName("fator")
                .HasColumnType("decimal(18,6)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
