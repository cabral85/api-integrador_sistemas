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
            IntegracaoMetodoPrimaria = new HashSet<IntegracaoMetodo>();
            IntegracaoMetodoSecundaria = new HashSet<IntegracaoMetodo>();
        }

        public int Id { get; set; }

        public string DscMetodo { get; set; }

        public int? IdClasse { get; set; }

        [StringLength(100)]
        public string comentario { get; set; }

        public virtual Classe Classe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntegracaoMetodo> IntegracaoMetodoPrimaria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntegracaoMetodo> IntegracaoMetodoSecundaria { get; set; }
    }
}
