namespace api_integrador_sistemas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_permissao")]
    public partial class Permissao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Permissao()
        {
            tbl_permissao_usuario_tela = new HashSet<PermissaoUsuarioTela>();
        }

        public int Id { get; set; }

        [StringLength(300)]
        public string dsc_permissao { get; set; }

        [StringLength(1)]
        public string ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissaoUsuarioTela> tbl_permissao_usuario_tela { get; set; }
    }
}
