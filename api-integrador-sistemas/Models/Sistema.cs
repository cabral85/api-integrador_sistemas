namespace api_integrador_sistemas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_sistema")]
    public partial class Sistema
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sistema()
        {
            tbl_classe = new HashSet<Classe>();
            tbl_integracao_sistema = new HashSet<IntegracaoSistema>();
            tbl_integracao_sistema1 = new HashSet<IntegracaoSistema>();
        }

        public int Id { get; set; }

        [Required]
        public string dsc_sistema { get; set; }

        public int id_repositorio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Classe> tbl_classe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntegracaoSistema> tbl_integracao_sistema { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntegracaoSistema> tbl_integracao_sistema1 { get; set; }

        public virtual Repositorio tbl_repositorio { get; set; }
    }
}
