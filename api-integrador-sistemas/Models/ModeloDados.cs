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

        public virtual DbSet<Classe> tbl_classe { get; set; }
        public virtual DbSet<Empresa> tbl_empresa { get; set; }
        public virtual DbSet<IntegracaoClasse> tbl_integracao_classe { get; set; }
        public virtual DbSet<IntegracaoMetodo> tbl_integracao_metodo { get; set; }
        public virtual DbSet<IntegracaoSistema> tbl_integracao_sistema { get; set; }
        public virtual DbSet<Metodo> tbl_metodo { get; set; }
        public virtual DbSet<Permissao> tbl_permissao { get; set; }
        public virtual DbSet<PermissaoUsuarioTela> tbl_permissao_usuario_tela { get; set; }
        public virtual DbSet<Repositorio> tbl_repositorio { get; set; }
        public virtual DbSet<Sistema> tbl_sistema { get; set; }
        public virtual DbSet<Tela> tbl_tela { get; set; }
        public virtual DbSet<Usuario> tbl_usuario { get; set; }

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
                .WithOptional(e => e.tbl_classe)
                .HasForeignKey(e => e.id_classe);

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
                .Property(e => e.dsc_metodo)
                .IsUnicode(false);

            modelBuilder.Entity<Metodo>()
                .Property(e => e.comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Metodo>()
                .HasMany(e => e.tbl_integracao_metodo)
                .WithOptional(e => e.MetodoPrimario)
                .HasForeignKey(e => e.id_metodo_primario);

            modelBuilder.Entity<Metodo>()
                .HasMany(e => e.tbl_integracao_metodo1)
                .WithOptional(e => e.MetodoSecundario)
                .HasForeignKey(e => e.id_metodo_primario);

            modelBuilder.Entity<Permissao>()
                .Property(e => e.dsc_permissao)
                .IsUnicode(false);

            modelBuilder.Entity<Permissao>()
                .Property(e => e.ativo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Permissao>()
                .HasMany(e => e.tbl_permissao_usuario_tela)
                .WithRequired(e => e.tbl_permissao)
                .HasForeignKey(e => e.id_permissao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PermissaoUsuarioTela>()
                .Property(e => e.ativo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Repositorio>()
                .Property(e => e.dsc_repositorio)
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
                .HasMany(e => e.tbl_sistema)
                .WithRequired(e => e.tbl_repositorio)
                .HasForeignKey(e => e.id_repositorio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sistema>()
                .Property(e => e.dsc_sistema)
                .IsUnicode(false);

            modelBuilder.Entity<Sistema>()
                .HasMany(e => e.tbl_classe)
                .WithOptional(e => e.sistema)
                .HasForeignKey(e => e.idSistema);

            modelBuilder.Entity<Sistema>()
                .HasMany(e => e.tbl_integracao_sistema)
                .WithOptional(e => e.tbl_sistema)
                .HasForeignKey(e => e.id_sistema_primario);

            modelBuilder.Entity<Sistema>()
                .HasMany(e => e.tbl_integracao_sistema1)
                .WithOptional(e => e.tbl_sistema1)
                .HasForeignKey(e => e.id_sistema_secundario);

            modelBuilder.Entity<Tela>()
                .Property(e => e.dsc_tela)
                .IsUnicode(false);

            modelBuilder.Entity<Tela>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Tela>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Tela>()
                .HasMany(e => e.tbl_permissao_usuario_tela)
                .WithRequired(e => e.tbl_tela)
                .HasForeignKey(e => e.id_tela)
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
                .HasMany(e => e.tbl_permissao_usuario_tela)
                .WithRequired(e => e.tbl_usuario)
                .HasForeignKey(e => e.id_usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
