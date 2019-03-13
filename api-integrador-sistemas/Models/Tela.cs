namespace api_integrador_sistemas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_tela")]
    public partial class Tela
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tela()
        {
            tbl_permissao_usuario_tela = new HashSet<PermissaoUsuarioTela>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string dsc_tela { get; set; }

        [StringLength(100)]
        public string titulo { get; set; }

        [StringLength(400)]
        public string url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissaoUsuarioTela> tbl_permissao_usuario_tela { get; set; }
    }
}
