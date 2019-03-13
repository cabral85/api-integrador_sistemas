namespace api_integrador_sistemas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_metodo")]
    public partial class Metodo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Metodo()
        {
            tbl_integracao_metodo = new HashSet<IntegracaoMetodo>();
            tbl_integracao_metodo1 = new HashSet<IntegracaoMetodo>();
        }

        public int Id { get; set; }

        public string dsc_metodo { get; set; }

        public int? id_classe { get; set; }

        [StringLength(100)]
        public string comentario { get; set; }

        public virtual Classe tbl_classe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntegracaoMetodo> tbl_integracao_metodo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntegracaoMetodo> tbl_integracao_metodo1 { get; set; }
    }
}
