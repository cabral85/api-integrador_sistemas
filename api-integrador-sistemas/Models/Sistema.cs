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
            Classe = new HashSet<Classe>();
            IntegracaoSistemaPrimaria = new HashSet<IntegracaoSistema>();
            IntegracaoSistemaSecundaria = new HashSet<IntegracaoSistema>();
        }

        public int Id { get; set; }

        [Required]
        public string DscSistema { get; set; }

        public int IdRepositorio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Classe> Classe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntegracaoSistema> IntegracaoSistemaPrimaria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntegracaoSistema> IntegracaoSistemaSecundaria { get; set; }

        public virtual Repositorio Repositorio { get; set; }
    }
}
