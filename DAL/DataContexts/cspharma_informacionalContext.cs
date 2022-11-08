using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.DataContexts
{
    public partial class cspharma_informacionalContext : DbContext
    {
        public cspharma_informacionalContext()
        {
        }

        public cspharma_informacionalContext(DbContextOptions<cspharma_informacionalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TdcCatEstadosDevolucionPedido> TdcCatEstadosDevolucionPedidos { get; set; } = null!;
        public virtual DbSet<TdcCatEstadosEnvioPedido> TdcCatEstadosEnvioPedidos { get; set; } = null!;
        public virtual DbSet<TdcCatEstadosPagoPedido> TdcCatEstadosPagoPedidos { get; set; } = null!;
        public virtual DbSet<TdcCatLineasDistribucion> TdcCatLineasDistribucions { get; set; } = null!;
        public virtual DbSet<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=cspharma_informacional;UserId=postgres;Password=Juancarbc2001;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TdcCatEstadosDevolucionPedido>(entity =>
            {
                entity.HasKey(e => e.MdUuid);

                entity.ToTable("tdc_cat_estados_devolucion_pedido", "dwh_torrecontrol");

                entity.Property(e => e.MdUuid).HasColumnName("Md_uuid");

                entity.Property(e => e.CodEstadoDevolucion).HasColumnName("Cod_estado_devolucion");

                entity.Property(e => e.DesEstadoDevolucion).HasColumnName("Des_estado_devolucion");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MdDate).HasColumnName("Md_date");
            });

            modelBuilder.Entity<TdcCatEstadosEnvioPedido>(entity =>
            {
                entity.HasKey(e => e.MdUuid);

                entity.ToTable("tdc_cat_estados_envio_pedido", "dwh_torrecontrol");

                entity.Property(e => e.MdUuid).HasColumnName("Md_uuid");

                entity.Property(e => e.CodEstadoEnvio).HasColumnName("Cod_estado_envio");

                entity.Property(e => e.DesEstadoEnvio).HasColumnName("Des_estado_envio");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MdDate).HasColumnName("Md_date");
            });

            modelBuilder.Entity<TdcCatEstadosPagoPedido>(entity =>
            {
                entity.HasKey(e => e.MdUuid);

                entity.ToTable("tdc_cat_estados_pago_pedido", "dwh_torrecontrol");

                entity.Property(e => e.MdUuid).HasColumnName("Md_uuid");

                entity.Property(e => e.CodEstadoPago).HasColumnName("Cod_estado_pago");

                entity.Property(e => e.DesEstadoPago).HasColumnName("Des_estado_pago");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MdDate).HasColumnName("Md_date");
            });

            modelBuilder.Entity<TdcCatLineasDistribucion>(entity =>
            {
                entity.HasKey(e => e.MdUuid);

                entity.ToTable("tdc_cat_lineas_distribucion", "dwh_torrecontrol");

                entity.Property(e => e.MdUuid).HasColumnName("Md_uuid");

                entity.Property(e => e.CodBarrio).HasColumnName("Cod_barrio");

                entity.Property(e => e.CodLinea).HasColumnName("Cod_linea");

                entity.Property(e => e.CodMunicipio).HasColumnName("Cod_municipio");

                entity.Property(e => e.CodProvincia).HasColumnName("Cod_provincia");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MdDate).HasColumnName("Md_date");
            });

            modelBuilder.Entity<TdcTchEstadoPedido>(entity =>
            {
                entity.HasKey(e => e.MdUuid);

                entity.ToTable("tdc_tch_estado_pedidos", "dwh_torrecontrol");

                entity.HasIndex(e => e.CodEstadoDevolucion, "IX_tdc_tch_estado_pedidos_Cod_estado_devolucion");

                entity.HasIndex(e => e.CodEstadoEnvio, "IX_tdc_tch_estado_pedidos_Cod_estado_envio");

                entity.HasIndex(e => e.CodEstadoPago, "IX_tdc_tch_estado_pedidos_Cod_estado_pago");

                entity.HasIndex(e => e.CodLinea, "IX_tdc_tch_estado_pedidos_Cod_linea");

                entity.Property(e => e.MdUuid).HasColumnName("Md_uuid");

                entity.Property(e => e.CodEstadoDevolucion).HasColumnName("Cod_estado_devolucion");

                entity.Property(e => e.CodEstadoEnvio).HasColumnName("Cod_estado_envio");

                entity.Property(e => e.CodEstadoPago).HasColumnName("Cod_estado_pago");

                entity.Property(e => e.CodLinea).HasColumnName("Cod_linea");

                entity.Property(e => e.CodPedido).HasColumnName("Cod_pedido");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MdDate).HasColumnName("Md_date");

                entity.HasOne(d => d.CodEstadoDevolucionNavigation)
                    .WithMany(p => p.TdcTchEstadoPedidos)
                    .HasForeignKey(d => d.CodEstadoDevolucion)
                    .HasConstraintName("FK_tdc_tch_estado_pedidos_tdc_cat_estados_devolucion_pedido_Co~");

                entity.HasOne(d => d.CodEstadoEnvioNavigation)
                    .WithMany(p => p.TdcTchEstadoPedidos)
                    .HasForeignKey(d => d.CodEstadoEnvio)
                    .HasConstraintName("FK_tdc_tch_estado_pedidos_tdc_cat_estados_envio_pedido_Cod_est~");

                entity.HasOne(d => d.CodEstadoPagoNavigation)
                    .WithMany(p => p.TdcTchEstadoPedidos)
                    .HasForeignKey(d => d.CodEstadoPago)
                    .HasConstraintName("FK_tdc_tch_estado_pedidos_tdc_cat_estados_pago_pedido_Cod_esta~");

                entity.HasOne(d => d.CodLineaNavigation)
                    .WithMany(p => p.TdcTchEstadoPedidos)
                    .HasForeignKey(d => d.CodLinea);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
