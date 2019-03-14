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

        public int? IdSistemaPrimario { get; set; }

        public int? IdSistemaSecundario { get; set; }

        public virtual Sistema SistemaPrimario { get; set; }

        public virtual Sistema SistemaSecundario { get; set; }
    }
}
