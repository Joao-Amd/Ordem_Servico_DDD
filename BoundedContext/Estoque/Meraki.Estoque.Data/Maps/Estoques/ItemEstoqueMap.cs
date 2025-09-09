using Meraki.Estoque.Domain.Estoques;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meraki.Estoque.Data.Maps.Estoques
{
    public class ItemEstoqueMap : IEntityTypeConfiguration<ItemEstoque>
    {
        public void Configure(EntityTypeBuilder<ItemEstoque> builder)
        {
            builder.ToTable("item_estoque");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedNever();

            builder.Property(p => p.IdItem)
                .HasColumnName("id_item")
                .IsRequired();

            builder.Property(p => p.Saldo)
                .HasColumnName("saldo")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.DataAtualizacao)
                .HasColumnName("data_atualizacao")
                .IsRequired();

            builder.HasOne(p => p.Item)
                .WithMany()
                .HasForeignKey(p => p.IdItem);
        }
    }
}
