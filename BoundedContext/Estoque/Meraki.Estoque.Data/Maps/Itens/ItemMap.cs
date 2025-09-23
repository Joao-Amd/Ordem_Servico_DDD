using Meraki.Estoque.Domain.Itens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meraki.Estoque.Data.Maps.Itens
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("item");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedNever();

            builder.Property(e => e.Identificacao)
                .HasColumnName("identificacao")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Ativo)
                .HasColumnName("ativo")
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("preco")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.IdUnidade)
                .HasColumnName("id_unidade")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(p => p.Unidade)
                .WithMany()
                .HasForeignKey(p => p.IdUnidade);
        }
    }
}
