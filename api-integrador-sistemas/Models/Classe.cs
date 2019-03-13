namespace api_integrador_sistemas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_classe")]
    public partial class Classe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Classe()
        {
            integracaoClassePrimaria = new HashSet<IntegracaoClasse>();
            integracaoClasseSecundaria = new HashSet<IntegracaoClasse>();
            metodo = new HashSet<Metodo>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string dscClasse { get; set; }

        public int? idSistema { get; set; }

        [StringLength(100)]
        public string comentario { get; set; }

        public virtual Sistema sistema { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntegracaoClasse> integracaoClassePrimaria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntegracaoClasse> integracaoClasseSecundaria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Metodo> metodo { get; set; }
    }
}
