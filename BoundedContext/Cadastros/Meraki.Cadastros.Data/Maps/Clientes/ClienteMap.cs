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

            builder.OwnsOne(p => p.DadosCorporativo, dc =>
            {
                dc.Property(c => c.RazaoSocial).HasColumnName("razao_social").HasMaxLength(200);
                dc.Property(c => c.Cnpj).HasColumnName("cnpj").HasMaxLength(14);
                dc.Property(c => c.NomeFantasia).HasColumnName("nome_fantasia").HasMaxLength(200);
                dc.Property(c => c.InscricaoEstadual).HasColumnName("inscricao_estadual").HasMaxLength(20);
                dc.Property(c => c.InscricaoMunicipal).HasColumnName("inscricao_municipal").HasMaxLength(20);
            });

            builder.OwnsOne(p => p.Endereco, e =>
            {
                e.Property(ep => ep.Logradouro).HasColumnName("logradouro").HasMaxLength(200).IsRequired();
                e.Property(ep => ep.Numero).HasColumnName("numero").HasMaxLength(20);
                e.Property(ep => ep.Bairro).HasColumnName("bairro").HasMaxLength(100).IsRequired();
                e.Property(ep => ep.Cidade).HasColumnName("cidade").HasMaxLength(100).IsRequired();
                e.Property(ep => ep.Uf).HasColumnName("estado").HasMaxLength(2).IsRequired();
                e.Property(ep => ep.Complemento).HasColumnName("complemento").HasMaxLength(100);
                e.OwnsOne(ep => ep.Cep, cep =>
                {
                    cep.Property(c => c.Numero)
                        .HasColumnName("cep")
                        .HasMaxLength(10)
                        .IsRequired();
                });
            });

            builder.OwnsOne(p => p.Contato, c =>
            {
                c.OwnsOne(cp => cp.Telefone, t =>
                {
                    t.Property(tp => tp.Numero).HasColumnName("telefone").HasMaxLength(20);
                });

                c.OwnsOne(cp => cp.Celular, c =>
                {
                    c.Property(tp => tp.Numero).HasColumnName("celular").HasMaxLength(20).IsRequired();
                });

                c.OwnsOne(cp => cp.Email, e =>
                {
                    e.Property(ep => ep.Endereco)
                        .HasColumnName("email")
                        .HasMaxLength(200)
                        .IsRequired();
                });
            });
        }
    }
}
