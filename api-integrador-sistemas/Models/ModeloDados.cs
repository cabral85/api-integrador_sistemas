namespace api_integrador_sistemas.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloDados : DbContext
    {
        public ModeloDados()
            : base("name=ModeloDados")
        {
        }

        public virtual DbSet<Classe> Classe { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<IntegracaoClasse> IntegracaoClasse { get; set; }
        public virtual DbSet<IntegracaoMetodo> IntegracaoMetodo { get; set; }
        public virtual DbSet<IntegracaoSistema> IntegracaoSistema { get; set; }
        public virtual DbSet<Metodo> Metodo { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<PermissaoUsuarioTela> PermissaoUsuarioTela { get; set; }
        public virtual DbSet<Repositorio> Repositorio { get; set; }
        public virtual DbSet<Sistema> Sistema { get; set; }
        public virtual DbSet<Tela> Tela { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classe>()
                .Property(e => e.dscClasse)
                .IsUnicode(false);

            modelBuilder.Entity<Classe>()
                .Property(e => e.comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Classe>()
                .HasMany(e => e.integracaoClassePrimaria)
                .WithRequired(e => e.ClassePrimaria)
                .HasForeignKey(e => e.IdClassePrimaria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classe>()
                .HasMany(e => e.integracaoClasseSecundaria)
                .WithRequired(e => e.ClasseSecundaria)
                .HasForeignKey(e => e.IdClasseSecundaria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classe>()
                .HasMany(e => e.metodo)
                .WithOptional(e => e.Classe)
                .HasForeignKey(e => e.IdClasse);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.nome_empresa)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.urlSite)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.ativo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.licenca)
                .IsUnicode(false);

            modelBuilder.Entity<Metodo>()
                .Property(e => e.DscMetodo)
                .IsUnicode(false);

            modelBuilder.Entity<Metodo>()
                .Property(e => e.comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Metodo>()
                .HasMany(e => e.IntegracaoMetodoPrimaria)
                .WithOptional(e => e.MetodoPrimario)
                .HasForeignKey(e => e.IdMetodoPrimario);

            modelBuilder.Entity<Metodo>()
                .HasMany(e => e.IntegracaoMetodoSecundaria)
                .WithOptional(e => e.MetodoSecundario)
                .HasForeignKey(e => e.IdMetodoSecundario);

            modelBuilder.Entity<Permissao>()
                .Property(e => e.DscPermissao)
                .IsUnicode(false);

            modelBuilder.Entity<Permissao>()
                .Property(e => e.Ativo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Permissao>()
                .HasMany(e => e.PermissaoUsuarioTela)
                .WithRequired(e => e.Permissao)
                .HasForeignKey(e => e.IdPermissao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PermissaoUsuarioTela>()
                .Property(e => e.Ativo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Repositorio>()
                .Property(e => e.DscRepositorio)
                .IsUnicode(false);

            modelBuilder.Entity<Repositorio>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Repositorio>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<Repositorio>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<Repositorio>()
                .Property(e => e.ativo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Repositorio>()
                .HasMany(e => e.Sistema)
                .WithRequired(e => e.Repositorio)
                .HasForeignKey(e => e.IdRepositorio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sistema>()
                .Property(e => e.DscSistema)
                .IsUnicode(false);

            modelBuilder.Entity<Sistema>()
                .HasMany(e => e.Classe)
                .WithOptional(e => e.sistema)
                .HasForeignKey(e => e.idSistema);

            modelBuilder.Entity<Sistema>()
                .HasMany(e => e.IntegracaoSistemaPrimaria)
                .WithOptional(e => e.SistemaPrimario)
                .HasForeignKey(e => e.IdSistemaPrimario);

            modelBuilder.Entity<Sistema>()
                .HasMany(e => e.IntegracaoSistemaSecundaria)
                .WithOptional(e => e.SistemaSecundario)
                .HasForeignKey(e => e.IdSistemaSecundario);

            modelBuilder.Entity<Tela>()
                .Property(e => e.DscTela)
                .IsUnicode(false);

            modelBuilder.Entity<Tela>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Tela>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Tela>()
                .HasMany(e => e.PermissaoUsuarioTela)
                .WithRequired(e => e.Tela)
                .HasForeignKey(e => e.IdTela)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.ativo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.sobrenome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.PermissaoUsuarioTela)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.IdUsuario)
                .WillCascadeOnDelete(false);
        }
    }
}
