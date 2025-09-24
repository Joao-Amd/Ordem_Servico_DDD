using Meraki.Cadastros.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meraki.Cadastros.Data.Maps.Clientes
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente"); 
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnName("ativo")
                .IsRequired();

            builder.Property(p => p.TipoPessoa)
                .HasColumnName("tipo_pessoa")
                .IsRequired();

            builder.OwnsOne(p => p.Cpf, cp =>
            {
                cp.Property(c => c.Numero)
                    .HasColumnName("cpf")
                    .HasMaxLength(11)
                    .IsRequired();
            });

            builder.Property(e => e.Identificacao)
                .HasColumnName("identificacao")
                .ValueGeneratedOnAdd();

        }
    }
}
