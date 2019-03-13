namespace api_integrador_sistemas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_empresa")]
    public partial class Empresa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string nome_empresa { get; set; }

        [StringLength(400)]
        public string urlSite { get; set; }

        public string descricao { get; set; }

        [StringLength(50)]
        public string telefone { get; set; }

        [StringLength(1)]
        public string ativo { get; set; }

        public string licenca { get; set; }
    }
}
