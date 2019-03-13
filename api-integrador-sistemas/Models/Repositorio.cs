namespace api_integrador_sistemas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_repositorio")]
    public partial class Repositorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Repositorio()
        {
            tbl_sistema = new HashSet<Sistema>();
        }

        public int Id { get; set; }

        [Required]
        public string dsc_repositorio { get; set; }

        [Required]
        public string url { get; set; }

        [Required]
        public string login { get; set; }

        [Required]
        public string senha { get; set; }

        [Required]
        [StringLength(1)]
        public string ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sistema> tbl_sistema { get; set; }
    }
}
