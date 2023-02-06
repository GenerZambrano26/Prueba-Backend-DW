using Microsoft.EntityFrameworkCore;
using Facturacion_API.Infraestructura.Entidades;

#nullable disable

namespace Facturacion_API.Infraestructura
{
    public partial class ContextDB : DbContext
    {
        public ContextDB()
        {
        }

        public ContextDB(DbContextOptions<ContextDB> options)
            : base(options)
        {
        }

        public virtual DbSet<Detallefactura> Detallefacturas { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Tercero> Terceros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=facturacion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Detallefactura>(entity =>
            {
                entity.HasKey(e => e.Cod);

                entity.Property(e => e.Cod)
                    .ValueGeneratedNever()
                    .HasColumnName("cod");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Codfactura).HasColumnName("codfactura");

                entity.Property(e => e.Codproducto).HasColumnName("codproducto");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.HasOne(d => d.CodfacturaNavigation)
                    .WithMany(p => p.Detallefacturas)
                    .HasForeignKey(d => d.Codfactura)
                    .HasConstraintName("Fk_Detallefacturas_Facturas_codfactura");

                entity.HasOne(d => d.CodproductoNavigation)
                    .WithMany(p => p.Detallefacturas)
                    .HasForeignKey(d => d.Codproducto)
                    .HasConstraintName("Fk_Detallefacturas_Productos_codproducto");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.Cod)
                    .HasName("PK_facturas");

                entity.Property(e => e.Cod)
                    .ValueGeneratedNever()
                    .HasColumnName("cod");

                entity.Property(e => e.Codtercero).HasColumnName("codtercero");

                entity.Property(e => e.Createdday).HasColumnName("createdday");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fechahora).HasColumnName("fechahora");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.CodterceroNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Codtercero);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Cod);

                entity.Property(e => e.Cod)
                    .ValueGeneratedNever()
                    .HasColumnName("cod");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("referencia");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<Tercero>(entity =>
            {
                entity.HasKey(e => e.Cod);

                entity.ToTable("Tercero");

                entity.Property(e => e.Cod)
                    .ValueGeneratedNever()
                    .HasColumnName("cod");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("apellido");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("direccion");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("identificacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
