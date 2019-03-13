namespace api_integrador_sistemas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            tbl_permissao_usuario_tela = new HashSet<PermissaoUsuarioTela>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string usuario { get; set; }

        [Required]
        public string senha { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        [StringLength(1)]
        public string ativo { get; set; }

        public string nome { get; set; }

        public string sobrenome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissaoUsuarioTela> tbl_permissao_usuario_tela { get; set; }
    }
}
