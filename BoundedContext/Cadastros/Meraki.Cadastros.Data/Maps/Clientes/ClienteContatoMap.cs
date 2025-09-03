using Meraki.Cadastros.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meraki.Cadastros.Data.Maps.Clientes
{
    public class ClienteContatoMap : IEntityTypeConfiguration<ClienteContato>
    {
        public void Configure(EntityTypeBuilder<ClienteContato> builder)
        {
            builder.ToTable("cliente_contato");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedNever();

            builder.OwnsOne(cp => cp.Telefone, t =>
            {
                t.Property(tp => tp.Numero).HasColumnName("telefone").HasMaxLength(20);
            });

            builder.OwnsOne(cp => cp.Celular, c =>
            {
                c.Property(tp => tp.Numero).HasColumnName("celular").HasMaxLength(20).IsRequired();
            });

            builder.OwnsOne(cp => cp.Email, e =>
            {
                e.Property(ep => ep.Endereco)
                    .HasColumnName("email")
                    .HasMaxLength(200)
                    .IsRequired();
            });

            builder.HasOne(p => p.Cliente)
                .WithOne(c => c.Contato)
                .HasForeignKey<ClienteContato>(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
