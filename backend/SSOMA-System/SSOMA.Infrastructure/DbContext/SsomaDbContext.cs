
using Microsoft.EntityFrameworkCore;
using SSOMA.Domain.Entities;

namespace SSOMA.Infrastructure.DbContext;

public partial class SsomaDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public SsomaDbContext(DbContextOptions<SsomaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccionesCorrectiva> AccionesCorrectivas { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Evidencia> Evidencias { get; set; }

    public virtual DbSet<Reporte> Reportes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccionesCorrectiva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("acciones_correctivas_pkey");

            entity.ToTable("acciones_correctivas");

            entity.HasIndex(e => e.Estado, "idx_accion_estado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaEjecucion).HasColumnName("fecha_ejecucion");
            entity.Property(e => e.FechaPlanificada).HasColumnName("fecha_planificada");
            entity.Property(e => e.ReporteId).HasColumnName("reporte_id");
            entity.Property(e => e.ResponsableId).HasColumnName("responsable_id");

            entity.HasOne(d => d.Reporte).WithMany(p => p.AccionesCorrectivas)
                .HasForeignKey(d => d.ReporteId)
                .HasConstraintName("acciones_correctivas_reporte_id_fkey");

            entity.HasOne(d => d.Responsable).WithMany(p => p.AccionesCorrectivas)
                .HasForeignKey(d => d.ResponsableId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("acciones_correctivas_responsable_id_fkey");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorias_pkey");

            entity.ToTable("categorias");

            entity.HasIndex(e => e.Nombre, "categorias_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Evidencia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("evidencias_pkey");

            entity.ToTable("evidencias");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaSubida)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_subida");
            entity.Property(e => e.ReporteId).HasColumnName("reporte_id");
            entity.Property(e => e.TipoArchivo)
                .HasMaxLength(50)
                .HasColumnName("tipo_archivo");
            entity.Property(e => e.UrlArchivo).HasColumnName("url_archivo");

            entity.HasOne(d => d.Reporte).WithMany(p => p.Evidencia)
                .HasForeignKey(d => d.ReporteId)
                .HasConstraintName("evidencias_reporte_id_fkey");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reportes_pkey");

            entity.ToTable("reportes");

            entity.HasIndex(e => e.CategoriaId, "idx_reporte_categoria_id");

            entity.HasIndex(e => e.Estado, "idx_reporte_estado");

            entity.HasIndex(e => e.FechaReporte, "idx_reporte_fecha");

            entity.HasIndex(e => e.UsuarioId, "idx_reporte_usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaReporte).HasColumnName("fecha_reporte");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("reportes_categoria_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("reportes_usuario_id_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Dni, "usuarios_dni_key").IsUnique();

            entity.HasIndex(e => e.Email, "usuarios_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Dni)
                .HasMaxLength(15)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
