namespace api_integrador_sistemas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_integracao_sistema")]
    public partial class IntegracaoSistema
    {
        public int Id { get; set; }

        public int? id_sistema_primario { get; set; }

        public int? id_sistema_secundario { get; set; }

        public virtual Sistema tbl_sistema { get; set; }

        public virtual Sistema tbl_sistema1 { get; set; }
    }
}
