using Meraki.Cadastros.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meraki.Cadastros.Data.Maps.Clientes
{
    public class ClienteEnderecoMap : IEntityTypeConfiguration<ClienteEndereco>
    {
        public void Configure(EntityTypeBuilder<ClienteEndereco> builder)
        {
            builder.ToTable("cliente_endereco");
            builder.HasKey(p => p.Id);

            builder.Property(ep => ep.Logradouro).HasColumnName("logradouro").HasMaxLength(200).IsRequired();
            builder.Property(ep => ep.Numero).HasColumnName("numero").HasMaxLength(20);
            builder.Property(ep => ep.Bairro).HasColumnName("bairro").HasMaxLength(100).IsRequired();
            builder.Property(ep => ep.Cidade).HasColumnName("cidade").HasMaxLength(100).IsRequired();
            builder.Property(ep => ep.Uf).HasColumnName("estado").HasMaxLength(2).IsRequired();
            builder.Property(ep => ep.Complemento).HasColumnName("complemento").HasMaxLength(100);

            builder.OwnsOne(ep => ep.Cep, cep =>
            {
                cep.Property(c => c.Numero)
                    .HasColumnName("cep")
                    .HasMaxLength(10)
                    .IsRequired();
            });

            builder.HasOne(p => p.Cliente)
                .WithOne(c => c.Endereco)
                .HasForeignKey<ClienteEndereco>(p => p.IdCliente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
